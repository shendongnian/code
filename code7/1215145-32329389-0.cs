    private readonly Action<string> _action;
    private UsernameDialog(Action<string> action)
    {
      _action = action;
    }
    public static void ShowDialogAsync(Action<string> action) 
    {
      var dialog = new UsernameDialog(action);
      dialog.Show();
    }
    // I wouldn't actually bind this to a button click, this is just an example
    public void btnOk_Click(object sender, EventArgs e)
    {
      _action(tbxUsername.Text);
      Close();
    }
