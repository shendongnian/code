    if(args != null && args.Contains("-CreateSchedule"))
    {
        using (TaskService ts = new TaskService())
		{
			// Get the company name 
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
			string companyName = versionInfo.CompanyName;
			
			// Set the program path
			string folderPath = string.Format(@"{0}\{1}", Environment.SpecialFolder.ProgramFiles.ToString(), companyName);
			string programPath = string.Format(@"{0}\program.exe", folderPath);
			// Create a new task definition and assign properties
			TaskDefinition td = ts.NewTask();
			td.RegistrationInfo.Description = "The program does what it does";
			// Set trigger and action and other properties...
			td.Principal.RunLevel = TaskRunLevel.Highest;
			// Create a trigger that will fire at the end of the month, every month
			td.Triggers.Add(new MonthlyTrigger { RunOnLastDayOfMonth = true });
			// Create an action that will launch the program whenever the trigger fires
			td.Actions.Add(new ExecAction(programPath, "'arg a' 'arg b' 'etc'", null));
			ts.RootFolder.RegisterTaskDefinition("TheTaskName", td);
		}
		
		// Don't let the program perform any other functions that aren't needed
        Exit();
    }
