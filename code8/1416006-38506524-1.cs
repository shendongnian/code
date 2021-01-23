    private List<TextBox> myTextBoxes { get; set; }
    
    public Form1()
    {
        InitializeComponent();
        foreach (Control c in this.Controls)
        {
            if (c.GetType() == typeof(TextBox))
                myTextBoxes.Add((TextBox)c);
        }
    }
    
    private IEnumerable<TextBox> getTop3()
    {
        return myTextBoxes.Where(tb => tb.Text.AsEnumerable().All(char.IsDigit)).Select(tb => tb).OrderByDescending(tb => Double.Parse(tb.Text)).Take(3);
    }
