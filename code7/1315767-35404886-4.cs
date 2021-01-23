    foreach (Control control in this.Controls)
        {
            if (control.GetType() == typeof(TextBox))
            {
                 TextBox textBox = (TextBox)control;
                 if (textBox.Text == String.Empty)
                 {
                     textBox.Focus();
                     textBox.BackColor = Color.Red;
                 }
            }
        }
