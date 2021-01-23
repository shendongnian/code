    private void validateText(TextBox tb)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb.Text, @"[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                    tb.Refresh();
                    tb.SelectionStart = tb.Text.Length;
                    tb.SelectionLength = 0;
                }
            }
