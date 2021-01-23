    private ITerminalContext mainContext;
    private ITerminalContext currentTerminalContext;
    public MainForm()
    {
        this.mainContext = new InitialTerminalContext(new ITerminalContext[]
        {
            new Terminal1Context(this),
            new Terminal1Context(this),
            ...
        });
    }              
    public void comboBox_SelectedChanged(object sender, EventArgs args)
    {
        var comboBox = (ComboBox)sender;
        this.currentTerminalContext = this.currentTerminalContext [comboBox.SelectedIndex];
    }
