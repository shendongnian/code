	public Int16 Write_To_Console_dr(string ConsoleCmd)
	{
		textBoxConsole.Text =  textBoxConsole.Text + ConsoleCmd + "\n" + "Tena_Console>";
		using(StreamWriter MySw = File.AppendText("akjsdh"))
		{
			MySw.WriteLine(ConsoleCmd, " \n");
		}
		return 1;
	}
	public Int16 Write_To_Console(string ConsoleCmd)
	{
		int retVal =  Write_To_Console_dr(ConsoleCmd);
		return 1;
	}
