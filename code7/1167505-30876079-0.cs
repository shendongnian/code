    if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
    {
        userNameTxtBox.Text = Request.Cookies["UserName"].Value;
        passwordTxtBox.Attributes["value"] = Request.Cookies["Password"].Value;
        chkBoxRememberMe.Checked = true; // <-- here
    }
