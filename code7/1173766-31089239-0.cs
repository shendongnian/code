    string oldText = string.Empty;
    int oldcaret = 0;
    protected override FrameworkElement GenerateEditingElement(DataGridCell cell, Object dataItem)
    {
        var textBox = (TextBox)base.GenerateEditingElement(cell, dataItem);
        textBox.PreviewTextInput += OnPreviewTextInput;
        textBox.TextChanged += OnTextChanged;
        return textBox;
    }
    private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        var textBox = (TextBox)sender;
        
        oldText = textBox.Text;
        oldCaret = textBox.CaretIndex;
    }
    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = (TextBox)sender;
        if (textBox.Text.Contains("-"))
        {
            textBox.Text = oldText;
            textBox.CaretIndex = oldCaret;
        }
    }
