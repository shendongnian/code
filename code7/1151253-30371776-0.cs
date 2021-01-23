        /// <summary>
        /// Assigns text to textBox.Text ignoring the event handler eventHandler for the event TextChanged.
        /// </summary>
        /// <param name="textBox">Text box control.</param>
        /// <param name="eventHandler">Event handler to ignore.</param>
        /// <param name="text">Text to assign.</param>
        public static void AssignSilently(TextBox textBox, EventHandler eventHandler, string text)
        {
            textBox.TextChanged -= eventHandler;
            textBox.Text = text;
            textBox.TextChanged += eventHandler;
        }
