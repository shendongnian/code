    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WbTest
    {
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        [ComDefaultInterface(typeof(IScripting))]
        public partial class MainForm : Form, IScripting
        {
            WebBrowser _webBrowser;
            Action _onScriptInitialized;
    
            public MainForm()
            {
                InitializeComponent();
    
                _webBrowser = new WebBrowser();
                _webBrowser.Dock = DockStyle.Fill;
                _webBrowser.ObjectForScripting = this;
                this.Controls.Add(_webBrowser);
    
                this.Shown += MainForm_Shown;
            }
    
            void MainForm_Shown(object sender, EventArgs e)
            {
                var dialog = new Form
                {
                    Width = 100,
                    Height = 50,
                    StartPosition = FormStartPosition.CenterParent,
                    ShowIcon = false,
                    ShowInTaskbar = false,
                    ControlBox = false,
                    FormBorderStyle = FormBorderStyle.FixedSingle
                };
                dialog.Controls.Add(new Label { Text = "Please wait..." });
    
                dialog.Load += (_, __) => _webBrowser.DocumentText = 
                    "<script>setTimeout(function() { window.external.OnScriptInitialized}, 2000)</script>";
    
                var canClose = false;
                dialog.FormClosing += (_, args) =>
                    args.Cancel = !canClose;
    
                _onScriptInitialized = () => { canClose = true; dialog.Close(); };
    
                Application.UseWaitCursor = true;
                try
                {
                    dialog.ShowDialog();
                }
                finally
                {
                    Application.UseWaitCursor = false;
                }
    
                MessageBox.Show("Initialized!");
            }
    
            // IScripting
            public void OnScriptInitialized()
            {
                _onScriptInitialized();
            }
        }
    
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IScripting
        {
            void OnScriptInitialized();
        }
    }
