    List<TextBox> _TextBoxes;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        _TextBoxes = new List<TextBox>();
        FindTextBoxes(Page, "xyz1");
    }
    private void FindTextBoxes(Control parent, string startsWith)
    { 
        if(parent.GetType()==typeof(TextBox) && parent.ID.StartsWith(startsWith))
        {
            _TextBoxes.Add(parent as TextBox);
        }
        foreach (var c in parent.Controls)
        {
            FindTextBoxes(c, startsWith);
        }
    }
