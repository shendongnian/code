		List<Command> commandList = new List<Command>();
		Command command1 = new Command("set-adserversettings");
		CommandParameter parameter1 = new CommandParameter("viewentireforest", true);
		command1.Parameters.Add(parameter1);
		commandList.Add(command1);
		Command command2 = new Command("set-userphoto");
		CommandParameter parameter2a = new CommandParameter("identity", tbxName.Text);
		CommandParameter parameter2b = new CommandParameter("picturedata", displayedImage);
		CommandParameter parameter2c = new CommandParameter("domaincontroller", "xx-xx-xx-01.xx.xx.xx.xxx");
		CommandParameter parameter2d = new CommandParameter("confirm", false);
		command2.Parameters.Add(parameter2a);
		command2.Parameters.Add(parameter2b);
		command2.Parameters.Add(parameter2c);
		command2.Parameters.Add(parameter2d);
		commandList.Add(command2);
		Pipeline pipeline;
		Collection<PSObject> exResults = null;
		
		foreach (Command cmd in commandList)
		{   
			pipeline = runspacee.CreatePipeline();
			pipeline.Commands.Add(cmd);
			
			exResults = pipeline.Invoke();
		}	
