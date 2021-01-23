    private void TextBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            var tb = sender as TextBox;
            if (Keyboard.Modifiers == ModifierKeys.Alt && Keyboard.IsKeyDown(Key.Enter))
            {
                int origSelectionStart = tb.SelectionStart;
                int paddingSpacesAmountToAdd = WidthInCells - (tb.Text.Substring(0, tb.SelectionStart)).Length%WidthInCells;
                int origPaddingSpacesAmountToAdd = paddingSpacesAmountToAdd;
                
                // Only if the cursor is in the end of the string - add one extra space that will be removed eventually.
                if (tb.SelectionStart == tb.Text.Length) paddingSpacesAmountToAdd++;
                string newText = tb.Text.Substring(0, tb.SelectionStart) + new String(' ', paddingSpacesAmountToAdd) + tb.Text.Substring(tb.SelectionStart + tb.SelectionLength);
                tb.Text = newText;
                
                int newSelectionPos = origSelectionStart + origPaddingSpacesAmountToAdd;
                tb.SelectionStart = newSelectionPos;
               
                e.Handled = true;
            }
            else if (Keyboard.IsKeyDown(Key.Enter))
            {
                //source already updated because of the binding UpdateSourceTrigger=PropertyChanged
                e.Handled = true;
            }
        }
