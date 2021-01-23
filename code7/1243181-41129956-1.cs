    public class LineLimitingBehavior : Behavior<TextBox>
    {
        public int? TextBoxMaxAllowedLines { get; set; }
        
        protected override void OnAttached()
        {
            if (TextBoxMaxAllowedLines == null || !(TextBoxMaxAllowedLines > 0)) return;
            
            AssociatedObject.PreviewTextInput += OnTextBoxPreviewTextInput;
            AssociatedObject.TextChanged += OnTextBoxTextChanged;
        }
        private void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.LineCount > TextBoxMaxAllowedLines.Value)
                Dispatcher.BeginInvoke(DispatcherPriority.Input, (Action)(() => textBox.Undo()));
        }
        private void OnTextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = (TextBox)sender;
            var currentText = textBox.Text;
            textBox.Text += e.Text;
            if (textBox.LineCount > TextBoxMaxAllowedLines.Value)
                e.Handled = true;
            textBox.Text = currentText;
            textBox.CaretIndex = textBox.Text.Length;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.PreviewTextInput -= OnTextBoxPreviewTextInput;
            AssociatedObject.TextChanged -= OnTextBoxTextChanged;
        }
    }
