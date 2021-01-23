    /// <summary> limits the number of lines the textbox will accept </summary>
    public class LineLimitingBehavior : Behavior<TextBox>
    {
        /// <summary> The maximum number of lines the textbox will allow </summary>
        public int? TextBoxMaxAllowedLines { get; set; }
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>
        /// Override this to hook up functionality to the AssociatedObject.
        /// </remarks>
        protected override void OnAttached()
        {
            if (TextBoxMaxAllowedLines != null && TextBoxMaxAllowedLines > 0)
                AssociatedObject.TextChanged += OnTextBoxTextChanged;
        }
        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>
        /// Override this to unhook functionality from the AssociatedObject.
        /// </remarks>
        protected override void OnDetaching()
        {
            AssociatedObject.TextChanged -= OnTextBoxTextChanged;
        }
        private void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int textLineCount = textBox.LineCount;
            //Use Dispatcher to undo - http://stackoverflow.com/a/25453051/685341
            if (textLineCount > TextBoxMaxAllowedLines.Value)
                Dispatcher.BeginInvoke(DispatcherPriority.Input, (Action) (() => textBox.Undo()));
        }
    }
