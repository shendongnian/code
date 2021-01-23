    foreach (Control co in this.Controls)
    {
        TextBox tb = co as TextBox;
        if (tb != null)
        {
            if (!String.IsNullOrWhiteSpace((string)tb.Tag))
            {
                MessageBox.Show(co.Name + "/" + co.Tag);
            }
            else
            {
                MessageBox.Show(co.Name + " ... without tag");
            }
        }
    }
