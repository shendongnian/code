    using System;
    using Microsoft.VisualBasic.ApplicationServices;
    using System.Windows.Forms;
    
    namespace Sample
    {
        public class ApplicationController : WindowsFormsApplicationBase
        {
            private Form mainForm;
            public ApplicationController(Form form)
            {
                //We keep a reference to main form 
                //To run and also use it when we need to bring to front
                mainForm = form;
                this.IsSingleInstance = true;
                this.StartupNextInstance += 
                    new StartupNextInstanceEventHandler(this_StartupNextInstance);
            }
    
            void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
            {
                //Here we bring application to front
                e.BringToForeground = true;
                mainForm.ShowInTaskbar = true;
                mainForm.WindowState = FormWindowState.Minimized;
                mainForm.Show();
                mainForm.WindowState = FormWindowState.Normal;
            }
            protected override void OnCreateMainForm()
            {
                this.MainForm = mainForm;
            }
        }
    }
