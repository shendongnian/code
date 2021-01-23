	public static bool callMacroProcess(String directory, String[] args, String process)
	{
		String realArgs = "";
		String nextArg = "";
		foreach (String arg in args)
		{
			if (arg.StartsWith("-p="))
			{
				String tmp = arg.Substring(3);
				String argType = arg.Substring(0, 3);
				if (!String.IsNullOrWhiteSpace(tmp))
				{
					realArgs += argType + "\"" + tmp + "\" ";
				}
				else
				{
					nextArg = argType + " ";
				}
			}
			else if (!String.IsNullOrWhiteSpace(nextArg)) //si l'argument précédent était seul
			{
				realArgs += nextArg + "\"" + arg + "\" ";
				nextArg = "";
			}
			else
			{
				realArgs += arg + " ";
			}
		}
		if (verbose)
		{
			Console.WriteLine("Arguments en parametres : " + realArgs);
		}
		System.Diagnostics.Process proc = new System.Diagnostics.Process();
		proc.StartInfo.CreateNoWindow = false;
		proc.StartInfo.UseShellExecute = false;
		proc.StartInfo = new System.Diagnostics.ProcessStartInfo(process, realArgs);
		proc.Start();
		return true;
	}
