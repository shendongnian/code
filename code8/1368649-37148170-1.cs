    public List<PrintMenuCommand> PrintMenuCommands { get; private set; } = new List<PrintMenuCommand>();
    public struct PrintMenuCommand
    {
    	public string CommandText { get; set; }
    
    	public string CommandShortcut { get; set; }
    
    	public ICommand Command { get; set; }
    }
    
    private void AddPrintOptions()
    {
    	PrintMenuCommands.Add(new PrintMenuCommand
    	{
    		CommandText = "Print",
    		CommandShortcut = "CTRL+P",
    		Command = new PrintCommand()
    	});
    }
