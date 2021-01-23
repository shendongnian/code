    private string _defaultResult;
    public InputBox(string LabelText, string Title, string DefaultResult)
    {
        InitializeComponent();
        myLabel.Text = LabelText;
        Text = Title;
        _defaultResult = myTextBox.Text = DefaultResult;
    }
    public string GetValue()
    {
        return this.DialogResult == DialogResult.OK ? myTextBox.Text : _defaultResult;
    }
