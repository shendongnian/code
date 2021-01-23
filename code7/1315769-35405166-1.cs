    foreach (Control co in this.Controls)
    {
        if (co.GetType() == typeof(TextBox))
        {
            TextBox tb = co as TextBox;
            MessageBox.Show(co.Name + "/" + co.Tag);
        }
    }
