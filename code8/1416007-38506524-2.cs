    public Form1()
    {
        InitializeComponent();
    
    }
    
    private IEnumerable<TextBox> getTop3(string textboxPrefix)
    {
        List<TextBox> textBoxesToSort = new List<TextBox>();
        foreach (Control c in this.Controls)
            if (c.GetType() == typeof(TextBox) && c.Name.StartsWith(textboxPrefix))
                textBoxesToSort.Add((TextBox)c);
    
        return textBoxesToSort.OrderByDescending(tb => Double.Parse(tb.Text)).Take(3);
    }
