    //note, this is untested code!
    public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
    {
    	handled = false;
    	if(executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
    	{
    		if(commandName == "ResetKeyBoard.Connect.ResetKeyBoard")
    		{
                System.Diagnostics.Debug.WriteLine("<UserShortcuts>");
                foreach (Command c in _applicationObject.Commands)
                {
                    if (!string.IsNullOrEmpty(c.Name))
                    {
                        System.Array bindings = default(System.Array);
                        bindings = (System.Array)c.Bindings;
                        for (int i = 0; i <= bindings.Length - 1; i++)
                        {
                            string scope = string.Empty;
                            string keyShortCut = string.Empty;
                            string[] binding = bindings.GetValue(i).ToString().Split(new string[] {  "::" },StringSplitOptions.RemoveEmptyEntries );
                            scope = binding[0];
                            keyShortCut = binding[1];
                            System.Diagnostics.Debug.WriteLine("<RemoveShortcut Command=\"...\" Scope=\"" + scope + "\">" + keyShortCut + "</RemoveShortcut>");
                            System.Diagnostics.Debug.WriteLine("<Shortcut Command=\"" + c.Name + "\" Scope=\"" + scope + "\">" + keyShortCut + "</Shortcut>");
                        }
                    }
                }
                System.Diagnostics.Debug.WriteLine("</UserShortcuts>");
	
