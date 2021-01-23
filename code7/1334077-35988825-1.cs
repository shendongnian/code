    public override void OnApplyTemplate()
    {
        DependencyObject ButtonControlInTemplate = GetTemplateChild("searchbutton");// set the name as the x:Name for the controls in your xaml.
        Button SearchButton = (Button)ButtonControlInTemplate;
        DependencyObject TextBoxInTemplate = GetTemplateChild("searchinputfield"); // set the name as the x:Name for the controls in your xaml.
        TextBox InputTextBox = (TextBox)TextBoxInTemplate; 
        base.OnApplyTemplate();
    }
