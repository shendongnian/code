			private static AutoResetEvent requestLogin = new AutoResetEvent();
			private static ManualResetEvent responseLogin = new ManualResetEvent();
			//Worker thread:
			if(!Api.IsLoggedIn) 
			{
				requestLogin.Set();
				responseLogin.WaitOne();
			}
			//Login thread
			requestLogin.WaitOne();
			if(!Api.IsLoggedIn)
			{
				Api.Login();
			}
			responseLogin.Set();
