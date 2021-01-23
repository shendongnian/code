    private async void btnLogin_Click(object sender, EventArgs e) {
        try {
            var t = await Api.LoginAsync( tbUsername.Text, tbPassword.Text);
            _Token = t.Result;
        }
        catch (Exception ex) {
            ShowError(ex.Message);
        }
    }
