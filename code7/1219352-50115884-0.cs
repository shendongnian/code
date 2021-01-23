    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace YourProjectNamespace
    {
        class ExWebBrowser : WebBrowser
        {
            void setLandscapeTimer_Tick(object sender, EventArgs e)
            {
                SendKeys.SendWait("%L");
                this.ProcessDialogKey(Keys.Alt & Keys.L);
                SendKeys.Flush();
            }
    
            public void _ShowPrintPreviewDialog()
            {
                this.ShowPrintPreviewDialog();
                this.Focus();
    
                Timer setLandscapeTimer = new Timer();
                setLandscapeTimer.Interval = 500;
                setLandscapeTimer.Tick += new EventHandler(setLandscapeTimer_Tick);
                setLandscapeTimer.Start();
            }
        }
    }
