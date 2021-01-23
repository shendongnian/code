        /// <summary>
        ///     Handle textbox on text changed event
        /// </summary>
        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            // Replace space with non-breaking space
            TestTextBox.Text = TestTextBox.Text.Replace(" ", "\u00a0");
            // Put the cursor at the end of the textbox (updating text sets the cursor at the start)
            TestTextBox.CaretIndex = TestTextBox.Text.Length;
        }
