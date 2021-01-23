    Admin singleResult = FrmMain.AdminL.Find(adm => 
        adm.UserName == txtUsername.Text);
    if(singleResult == null)
    {
        MsgBox("No User found");
        return; // exit the subroutine you're in
    }
    if(singleResult.PassWord != txtPassword.Text)
    {
        MsgBox("Wrong Password");
        return; // exit the subroutine you're in
    }
    if(singleResult.Permitted == false)
    {
        MsgBox("Not authorized")
        return;
    }
