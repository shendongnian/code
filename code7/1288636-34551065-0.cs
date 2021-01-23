    private async void btnLogin_Click(object sender, EventArgs e) {
        try {
            _Token  = await Api.LoginAsync( tbUsername.Text, tbPassword.Text);
        }
        catch (Exception ex) {
            ShowError(ex.Message);
        }
    }
