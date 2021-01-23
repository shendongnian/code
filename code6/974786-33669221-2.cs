    public partial class Launcher : Form
    {
        /// <summary>Collection of process. </summary>
        private Dictionary<IntPtr, Process> _processCollection = new Dictionary<IntPtr, Process>();
        #region DLL Import
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        #endregion
        /// <summary>Default constructor. </summary>
        public Launcher()
        {
            InitializeComponent();
            try {
                FormClosing += Launcher_FormClosing;
                StartInstances();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>Starts the instances. </summary>
        private void StartInstances()
        {
            var path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            var numberOfInstances = Int32.Parse(ConfigurationManager.AppSettings["NumerOfInstances"]);
            for (int i = 0; i < numberOfInstances; i++) {
                StartInstance(i, path);
            }
        }
        /// <summary>Starts an instance. </summary>
        private void StartInstance(int instanceId, string path)
        {
            Process proc = Process.Start(path + "\\foo.exe", instanceId.ToString());
            IntPtr handlerDocked = IntPtr.Zero;
            Panel panel = new Panel();
            panel.Size = new Size(flwPanel.Width / 3, flwPanel.Height / 2);
            flwPanel.Controls.Add(panel);
            do {
                try {
                    proc.WaitForInputIdle(1000); //wait for the window to be ready for input;
                    proc.Refresh();              //update process info
                    if (proc.HasExited) {
                        return; //abort if the process finished before we got a handle.
                    }
                    handlerDocked = proc.MainWindowHandle;  //cache the window handle
                }
                catch {
                    Thread.Sleep(500);
                }
            } while (handlerDocked == IntPtr.Zero);
            //hWndOriginalParent = SetParent(hWndDocked, panel1.Handle);
            SetParent(handlerDocked, panel.Handle);
            var docked = new DockedElement(handlerDocked, panel);
            panel.SizeChanged += new EventHandler(Panel_Resize);
            Panel_Resize(docked, new EventArgs());
            _processCollection.Add(handlerDocked, proc);
        }
        private void Panel_Resize(object sender, EventArgs e)
        {
            var docked = (DockedElement)sender;
            //Change the docked windows size to match its parent's size. 
            MoveWindow(docked.Handle, 0, 0, docked.Container.Width, docked.Container.Height, true);
        }
        /// <summary>Finallize instances. </summary>
        public void FinallizeInstances()
        {
            foreach (var docked in _processCollection) {
                docked.Value.Close();
            }
            _processCollection.Clear();
        }
        private void Launcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinallizeInstances();
        }
        protected override void Dispose(bool disposing)
        {
            FinallizeInstances();
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
   
