    foreach (TextBox item in this.Controls.OfType<TextBox>()) {
        if (item.Text.Trim() == "") {
           MessageBox.Show(item.Tag.ToString());
        }
    }
