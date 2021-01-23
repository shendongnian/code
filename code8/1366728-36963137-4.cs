    private InputBox() // Constructor is private
    {
        InitializeComponent();
    }
    
    public static string GetValue(string LabelText, string Title, string DefaultResult)
    {
        using(var form = new InputBox())
        {
           form.myLabel.Text = labelText;
           form.Text = Title;
           form.myTextBox.Text = DefaultResult;
           if(form.ShowDialog() == DialogResult.OK)
             return form.myTextBox.Text;
        }
        return DefaultResult;
    }
