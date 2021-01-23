	using System.Timers;
	public class Test
	{
		// Session is the player
		static Timer FightTimer = null;
		
		public static void Main(Session Session)
		{
			FightTimer = new Timer(1000); // one second interval
			// Hook up the Elapsed event for the timer.
			FightTimer.Elapsed += new ElapsedEventHandler(Fight);
			// Set the Interval to 1 seconds
			FightTimer.Interval = 1000;
			FightTimer.Enabled = true;
		}
		public static void Fight(object attacker)
		{
			// get the session
			Session Session = (Session)attacker;
			if (Session.CharacterInfo.IsDestroy == true)
			{
				return;
			}
			// Ok here will be calculated all damage and ect...
			// if there's no others "return" for stopping the execution we can let the timer call
			// the callback again. if not, the timer is stopped and disposed
			FightTimer.Enabled = false;
			// modify to your needs
		}
	}
