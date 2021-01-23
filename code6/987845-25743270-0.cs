        private void PrepareEditor(string initalText)
        {
            var run = new Run(initalText);
            if (IsSelectionFormat(TextElement.FontWeightProperty, FontWeights.Bold))
            {
                run.FontWeight = FontWeights.Bold;
            }
            if (IsSelectionFormat(TextElement.FontStyleProperty, FontStyles.Italic))
            {
                run.FontStyle = FontStyles.Italic;
            }
            if (IsSelectionFormat(Inline.TextDecorationsProperty, TextDecorations.Underline))
            {
                run.TextDecorations = TextDecorations.Underline;
            }
            double fontSize;
            if (double.TryParse(CmbFontSize.Text, out fontSize))
                run.FontSize = FontSizeHelper.PxToPt(fontSize);
            if (CmbFontFamily.Text != "")
                run.FontFamily = new FontFamily(CmbFontFamily.Text);
            Editor.Document.Blocks.Clear();
            Editor.Document.Blocks.Add(new Paragraph(run));
        }
        private bool IsSelectionFormat(DependencyProperty formattingProperty, object expectedValue)
        {
            object currentValue = Editor.Selection.GetPropertyValue(formattingProperty);
            var active = (currentValue != DependencyProperty.UnsetValue) && (currentValue != null && currentValue.Equals(expectedValue));
            return active;
        }
        private void Editor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // If the editor is empty, the Run element is sometimes missing, so we need to add it and apply any selected formating manually!
            if (Editor.PlainText() == "" && Editor.CaretPosition.GetInsertionPosition(LogicalDirection.Forward).Parent.GetType() != typeof(Run))
            {
                PrepareEditor(e.Text);
                e.Handled = true;
            }
        }
        private void Editor_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Editor.PlainText().Trim() == "" && Editor.CaretPosition.GetInsertionPosition(LogicalDirection.Forward).Parent.GetType() != typeof(Run))
            {
                PrepareEditor("");
            }
            // More code ...
        }
