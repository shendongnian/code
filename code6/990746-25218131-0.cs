    private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if (this.RichText.Selection != null)
        {
            var currentValue = new TextRange(this.RichText.Selection.Start, this.RichText.Selection.End);
            if (currentValue.GetPropertyValue(Inline.TextDecorationsProperty) == TextDecorations.Underline)
            {
                this.UnderlineButton.IsChecked = true;
            }
            else
            {
                this.UnderlineButton.IsChecked = false;
            }
    }
