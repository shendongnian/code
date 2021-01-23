    List<Admin> result = FrmMain.AdminL.FindAll(adm => 
        adm.UserName == txtUsername.Text && 
        adm.PassWord == txtPassword.Text);
    if (result.Count == 1)
    {
      // authenticated 
    }
    else
    {
      // not authenticated
    }
    List<Admin> result = FrmMain.AdminL.FindAll(adm => 
        adm.UserName == txtUsername.Text && 
        adm.Permitted  == true);
    if (result.Count == 1)
    {
      // username is permitted to access
    }
