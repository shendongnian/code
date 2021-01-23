    #region namespace Xy.Sap
    namespace Xy.Sap
    {
        using System.Reflection;
        using sapfewse;
        using saprotwr.net;
        using COMException = System.Runtime.InteropServices.COMException;
    
        public static class SapHelper
        {
            public static GuiSession GetActiveSession()
            {
                var rot = new CSapROTWrapper().GetROTEntry("SAPGUI");
                if (rot == null)
                    throw SapException.NotOpened();
    
                var app = (GuiApplication)rot.GetType().InvokeMember("GetScriptingEngine", BindingFlags.InvokeMethod, null, rot, null);
                var connectedSession = app.Connections.Cast<GuiConnection>()
                    .SelectMany(x => x.Children.Cast<GuiSession>())
                    .Where(x => !string.IsNullOrEmpty(x.Info.User))
                    .FirstOrDefault();
    
                if (connectedSession == null)
                    throw SapException.NotOpened();
    
                return connectedSession;
            }
        }
    
        public class SapException : Exception
        {
            public SapException(string message) : base(message) { }
    
            public static SapException NotOpened()
            {
                return new SapException("Veuillez lancer le SAP et de connecter avec votre identité");
            }
        }
    
        public static class SapExtensions
        {
            #region GuiSession
    
            /// <summary>
            /// Shortcut for PA20 query
            /// </summary>
            /// <param name="session"></param>
            /// <param name="employeeID"></param>
            /// <param name="it">Infotype ID</param>
            /// <param name="sty">Subtype ID</param>
            /// <param name="asListView"></param>
            /// <returns></returns>
            public static GuiFrameWindow QueryPA20(this GuiSession session, int employeeID, string it, string sty = null, bool asListView = false)
            {
                var window = session.BeginTransaction("PA20", "Afficher données de base personnel");
                window.FindByName<GuiCTextField>("RP50G-PERNR").Text = employeeID.ToString();
                window.FindByName<GuiCTextField>("RP50G-CHOIC").Text = it;
                window.FindByName<GuiCTextField>("RP50G-SUBTY").Text = sty;
                window.FindByName<GuiButton>(asListView ? "btn[20]" : "btn[7]").Press();
    
                if (window.Text == "Afficher données de base personnel")
                {
                    var exception = new InvalidOperationException(string.Format("Failed to access to personal information of {0}", employeeID));
                    exception.Data["Employee ID"] = employeeID;
                    exception.Data["Infotype"] = it;
                    exception.Data["Subtype"] = sty;
                    exception.Data["View"] = asListView ? "ListView[Mont]" : "RecordView[Glasses]";
                    exception.Data["Status Message"] = window.FindByName<GuiStatusbar>("sbar").Text;
    
                    throw exception;
                }
    
                return window;
            }
    
            /// <summary>
            /// Shortcut for PA30 query
            /// </summary>
            /// <param name="session"></param>
            /// <param name="employeeID"></param>
            /// <param name="it">Infotype ID</param>
            /// <param name="sty">Subtype ID</param>
            /// <param name="asListView"></param>
            /// <returns></returns>
            public static GuiFrameWindow QueryPA30(this GuiSession session, int employeeID, string it, string sty = null)
            {
                var window = session.BeginTransaction("PA30", "Gérer données de base HR");
                window.FindByName<GuiCTextField>("RP50G-PERNR").Text = employeeID.ToString();
                window.FindByName<GuiCTextField>("RP50G-CHOIC").Text = it;
                window.FindByName<GuiCTextField>("RP50G-SUBTY").Text = sty;
                window.FindByName<GuiButton>("btn[6]").Press();
    
                if (window.Text == "Gérer données de base HR")
                {
                    var exception = new InvalidOperationException(string.Format("Failed to access to personal information of {0}", employeeID));
                    exception.Data["Employee ID"] = employeeID;
                    exception.Data["Infotype"] = it;
                    exception.Data["Subtype"] = sty;
                    exception.Data["Status Message"] = window.FindByName<GuiStatusbar>("sbar").Text;
    
                    throw exception;
                }
    
                return window;
            }
    
    
            /// <summary>
            /// Start a new transaction and return the active window
            /// </summary>
            public static GuiFrameWindow BeginTransaction(this GuiSession session, string transactionID, string expectedTitle)
            {
                return session.BeginTransaction(transactionID,
                    x => x.Text == expectedTitle,
                    x =>
                    {
                        var exception = new InvalidOperationException(string.Format("Failed to open transaction : {0}", transactionID));
                        exception.Data["Transaction ID"] = transactionID;
                        exception.Data["Expected Title"] = expectedTitle;
                        exception.Data["Current Title"] = x.Text;
                        exception.Data["Status Message"] = x.FindByName<GuiStatusbar>("sbar").Text;
    
                        return exception;
                    });
            }
            public static GuiFrameWindow BeginTransaction(this GuiSession session, string transactionID, Predicate<GuiFrameWindow> validation, Func<GuiFrameWindow, string> errorFormatter)
            {
                return session.BeginTransactionImpl(transactionID, validation, x => new Exception(errorFormatter(x)));
            }
            public static GuiFrameWindow BeginTransaction(this GuiSession session, string transactionID, Predicate<GuiFrameWindow> validation, Func<GuiFrameWindow, Exception> errorBuilder)
            {
                return session.BeginTransactionImpl(transactionID, validation, errorBuilder);
            }
            private static GuiFrameWindow BeginTransactionImpl(this GuiSession session, string transactionID, Predicate<GuiFrameWindow> validation, Func<GuiFrameWindow, Exception> errorBuilder)
            {
                // force current transaction to end, preventing any blocking(eg: model dialog)
                session.EndTransaction();
    
                session.StartTransaction(transactionID);
                var window = session.ActiveWindow;
                if (!validation(window))
                    throw errorBuilder(window);
    
                return window;
            }
    
            #endregion
            #region GuiFrameWindow
    
            public static TSapControl FindByName<TSapControl>(this GuiFrameWindow window, string name)
            {
                try
                {
                    return (TSapControl)window.FindByName(name, typeof(TSapControl).Name);
                }
                catch (COMException e)
                {
                    var writer = new StringWriter();
                    writer.WriteLine("The control could not be found by name and type.");
                    writer.WriteLine("Name : " + name);
                    writer.WriteLine("Type : " + typeof(TSapControl).Name);
    
                    throw new Exception(writer.ToString(), e);
                }
            }
    
            #endregion
            #region GuiTableControl
    
            /// <summary>Note: Do not iterate through this ienumerable more than once</summary>
            public static IEnumerable<GuiTableRow> AsEnumerable(this GuiTableControl table)
            {
                var container = table.Parent as dynamic;
                string name = table.Name, type = table.Type;
                int rowCount = table.VerticalScrollbar.Maximum;
    
                Func<GuiTableControl> getTable = () => container.FindByName(name, type) as GuiTableControl;
    
                for (int i = 0; i <= rowCount; i++)
                {
                    getTable().VerticalScrollbar.Position = i;
                    yield return getTable().Rows.Item(0) as GuiTableRow;
                }
            }
    
            public static TSapControl GetCell<TSapControl>(this GuiTableRow row, int column)
            {
                return (TSapControl)row.Item(column);
            }
            public static string GetCText(this GuiTableRow row, int column)
            {
                return row.GetCell<GuiCTextField>(column).Text;
            }
            public static string GetText(this GuiTableRow row, int column)
            {
                return row.GetCell<GuiTextField>(column).Text;
            }
            #endregion
        }
    }
    #endregion
