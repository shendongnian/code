            if (FocusedTextComboBox is TextBox)
            {
                TextBox tb = (TextBox)FocusedTextComboBox;
                if (SearchTextBox.SelectionStart == 0 && SearchTextBox.Text != "")
                {
                    switch (shift)
                    {
                        case true:
                            tb.Text += upperCaseChar;
                            break;
                        case false:
                            tb.Text += lowerCaseChar;
                            break;
                    }
                }
                else
                {
                    int SelectionStartNumber = tb.SelectionStart;
                    switch (shift)
                    {
                        case true:
                            tb.Text = tb.Text.Insert(tb.SelectionStart, upperCaseChar);
                            break;
                        case false:
                            tb.Text = tb.Text.Insert(tb.SelectionStart, lowerCaseChar);
                            break;
                    }
                    tb.SelectionStart = SelectionStartNumber + 1;
                }
            }
