    protected void Page_Init(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            LoadControls();
        }
    }
    
    protected void OkButton_Click(object sender, EventArgs e)
    {
        LoadControls();
    }
    
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        var myTextBox = FindControlRecursive(PlaceHolder1, "MyTextBox") as TextBox;
        MessageLabel.Text = myTextBox.Text;
    }
    
    private void LoadControls()
    {
        // Ensure that the control hasn't been added yet. 
        if (FindControlRecursive(PlaceHolder1, "MyTextBox") == null)
        {
            var myTextBox = new TextBox {ID = "MyTextBox"};
            PlaceHolder1.Controls.Add(myTextBox);
        }
    }
    
    public static Control FindControlRecursive(Control root, string id)
    {
        if (root.ID == id)
            return root;
    
        return root.Controls.Cast<Control>()
            .Select(c => FindControlRecursive(c, id))
            .FirstOrDefault(c => c != null);
    }
