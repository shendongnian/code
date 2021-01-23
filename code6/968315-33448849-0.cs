    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.SessionState;
    namespace Proposal_Sln
    {
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed+=timer_Elapsed;
            timer.Start();
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Models.Proposal_DBEntities DB = new Models.Proposal_DBEntities();
            Models.tbl_Year Y = new Models.tbl_Year();
            Y.YearName = "13" + DateTime.Now.Second.ToString();
            DB.tbl_Year.Add(Y);
            DB.SaveChanges();
        }
     }
    }
