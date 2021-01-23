    private const int Step = 10
    private int y = 0;
    public ThisDoesWork(string n) 
    {
      CheckBox checkBox = new CheckBox
		{
			Text = n,
			Top = y,
			Parent = panel1
		};
		y += checkBox.Height + Step; // you can set any rules for the postition of new controls
    }
