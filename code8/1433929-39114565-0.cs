    Class Controller
    {
     public static frmLOGIN log = new frmLOGIN();
     public static frmREGISTER reg = new frmREGISTER();
     public static frmACCOUNTS acc = new frmACCOUNTS();
     public static void FormOpen(string form_name)
     {
        if(form_name == "accounts")
         {
            acc.Show();
         }
        else if (form_name == "register")
         {
           reg.Show();
         }
        else if (form_name == "login")
         {
           log.Show();
         }
     }
    }
