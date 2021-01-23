    Timer timer = new Timer();
			timer.Interval = 3600000; 
			timer.AutoReset = false; 
			timer.Start ();
			timer.Elapsed+= Timer_Elapsed;
		
		void Timer_Elapsed (object sender, ElapsedEventArgs e)
		{
			Console.WriteLine("Timer has gone off");
		}
