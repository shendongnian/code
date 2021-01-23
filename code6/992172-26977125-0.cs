            TextBox.Text = _Text;
            System.Windows.Input.Keyboard.Focus(TextBox);
            TextBox.GotFocus += (sender, e) => {
                if (_selectAll)
                {
                    //I think Caret can be set here but I didn't try it
                    TextBox.SelectAll();
                }
            };
