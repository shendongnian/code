        public class CustomApplicationContext : ApplicationContext
        {
            Form mainForm = null;
            Timer timer = new Timer();
    
            public CustomApplicationContext(Form mainForm,Form timed):base(timed)
            {
                this.mainForm = mainForm;
    
                timer.Tick += new EventHandler(SplashTimeUp);
                timer.Interval = 30000;
                timer.Enabled = true;
            }
    
            private void SplashTimeUp(object sender, EventArgs e)
            {
                timer.Enabled = false;
                timer.Dispose();
    
                base.MainForm.Close();
            }
    
            protected override void OnMainFormClosed(object sender, EventArgs e)
            {
                if (sender is Form1)
                {
                    base.MainForm = this.mainForm;
                    base.MainForm.Show();
                }
                else if (sender is Form2)
                {
                    base.OnMainFormClosed(sender, e);
                }
            }
    
            
        }
