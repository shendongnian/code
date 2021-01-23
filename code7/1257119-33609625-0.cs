    protected void Button1_Click(object sender, EventArgs e)
    {
      var button = (IButton)sender;
      // assuming id is Int32
      int id = int.Parse(button.CommandArgument);
    }
