    public partial class DepartmentScreen : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var u = System.Security.Principal.WindowsIdentity.GetCurrent().User;
                var UserName = u.Translate(Type.GetType("System.Security.Principal.NTAccount")).Value;
                CheckForNewOrders(_refDate);
            }
            private DateTime _refDate = DateTime.MinValue;
            private void CheckForNewOrders(DateTime dt)
            {
                string json = null;
                string conStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conStr))
                {
                    string query = string.Format(@"
                        SELECT [Order].OrderId, [Order].CreatedOn
                        FROM [dbo].[Order]
                        WHERE [Order].CreatedOn >= @CreatedOn");
                    //                query = string.Format(@"
                    //                        SELECT [Order].OrderId
                    //                        FROM [dbo].[Order]
                    //                        WHERE [Order].StatusId = 1");
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@CreatedOn", SqlDbType.DateTime);
                        command.Parameters["@CreatedOn"].Value = dt;
                        command.Notification = null;
                        SqlDependency dependency = new SqlDependency(command);
                        dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //json = reader[0].ToString();
                                var date = Convert.ToDateTime(reader["CreatedOn"]);
                                if (date > _refDate)
                                {
                                    _refDate = date;
                                }
                            }
                        }
                    }
                }
                //SignalRHub hub = new SignalRHub();
                //hub.OrderReceived(json, null);
            }
            private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
            {
                if (e.Type == SqlNotificationType.Change)
                {
                    CheckForNewOrders(_refDate);
                }
                else
                {
                    //Do somthing here
                    //Console.WriteLine(e.Type);
                }
            }
        }
    }
