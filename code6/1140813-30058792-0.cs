     protected void txtDate_OnDataBinding(object sender, System.EventArgs e)
    {
    TextBox txt = (TextBox)(sender);
    txt.Text = (DateTime)(Bind("YourDateField")).ToString("MM/dd/yyyy");
    }
