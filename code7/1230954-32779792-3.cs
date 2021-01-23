    public class Global : HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{
			...//your current code
			SendEmail();
			SetUpTimer();
		}
		private static System.Threading.Timer _timer;
		private void SetUpTimer()
		{
			TimeSpan timeToGo = DateTime.Now.AddDays(1).Date - DateTime.Now; //timespan for 00:00 tommorrow 
			_timer = new System.Threading.Timer(x => SendEmail(), null, timeToGo, new TimeSpan(1,0,0,0));
		}
		public void SendEmail()
		{
			//check if email was sent today if not send one
		}
	}
