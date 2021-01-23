    public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
    		{
    			handled = false;
    			if(executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
    			{
    				if(commandName == "ResetKeyBoard.Connect.ResetKeyBoard")
    				{
                        _applicationObject.ExecuteCommand("Tools.Options", "BAFF6A1A-0CF2-11D1-8C8D-0000F87570EE");
                        System.Windows.Forms.SendKeys.Send("%e");
                        System.Windows.Forms.SendKeys.Send("{ENTER}");
