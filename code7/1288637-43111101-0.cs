    private void btnLogin_Click(object sender, EventArgs e) {
        try {
            var task= Task.Run(async () =>
                       {
                           return await Api.LoginAsync( tbUsername.Text, tbPassword.Text);
                       });
             _Token  = task.Result; 
        }
        catch (Exception ex) {
            ShowError(ex.Message);
        }
    }
