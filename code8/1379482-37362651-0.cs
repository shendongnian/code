           if (textemail.Text != "" && !remail.IsMatch(textemail.Text))
                {
                    errorProvider1.Clear();
                    textemail.Focus();
                    errorProvider1.SetError(textemail, "Wrong Email ID");
                    MessageBox.Show("Wrong Email ID");
                    textemail.SelectAll();
                    return;
                }
