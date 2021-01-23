    public static void system(string command)
		{
			//No arguments
			if(command.IndexOf(' ')== -1)
			{
				Process.Start(command);
			}
			else 
			{
				string cmd = command.Substring(0, command.IndexOf(' '));
				string args = command.Substring(command.IndexOf(' ')+1);
				Process.Start(cmd, args);
			}
		}
