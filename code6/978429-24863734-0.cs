    public partial class ThisAddIn
        {
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                Thread thread = new Thread(p =>
                {
                    DateTime now = DateTime.Now;
                    DateTime endOfDay = DateTime.Today.AddDays(1);
                    TimeSpan timeLeftForClose = endOfDay.Subtract(now);
                    Thread.Sleep(timeLeftForClose);
                    this.Application.Quit();                    
                });
                thread.Start();
            }
    
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
            }
    
           
            private void InternalStartup()
            {
                this.Startup += new System.EventHandler(ThisAddIn_Startup);
                this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
            }
            
           
        }
