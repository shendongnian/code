      public class KyuApplication : System.Web.HttpApplication
      {
        public override void Init()
        {
            SessionStateModule session = Modules["Session"] as SessionStateModule;
            if (session != null)
            {
                session.Start += new EventHandler(Session_Start);
                session.End += new EventHandler(Session_End);
            }
        }
        private void Session_Start(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session_Start");
        }
        private void Session_End(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session_End");
        }
    }
