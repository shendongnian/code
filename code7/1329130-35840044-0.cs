    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
       if(lstParameters.SelectedIndex >= 0 && !String.IsNullOrWhiteSpace(TextBox1.Text))
       {
           ListItem selectedItem = lstParameters.Items[lstParameters.SelectedIndex];
           selectedItem.Text = TextBox1.Text;
       }
    }
