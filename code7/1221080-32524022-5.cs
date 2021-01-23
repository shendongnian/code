    public void btnLogon_Click()
            {
                
               if (LoginSet == false )
               {
                    string[] txtSome = Request.Cookies["UserSettings"].Value.Split('&');
                    if (Request.Cookies["UserSettings"] != null && txtEmailVal != "" && txtPassword != "")
                    {
                        txtEmailVal = txtSome[0].Trim();
                        txtPassword = txtSome[1].Trim();
    
                    }
    
                    String[] RemoteAddr = Request.ServerVariables.GetValues("REMOTE_ADDR");
                    if (RemoteAddr.Length <= 0)
                        return;
    
                    LoginDB oLoginDb = new LoginDB(txtEmailVal, txtPassword, true, RemoteAddr[0].ToString());
                    oLoginDb.Database = new SQLDatabase(Convert.ToString(ConfigurationManager.ConnectionStrings["dbConnectionString"].ToString()));
    
                    try
                    {
                        if (oLoginDb.Authenticate(ConfigurationManager.AppSettings["SecKeyIni"].ToString(), ConfigurationManager.AppSettings["SecKeySec"].ToString()))
                        {
                            
                            Session["IdUserLogin"] = txtEmailVal;
                           
                           _loginSet = true;
                           HttpCookie myCookie = new HttpCookie("UserSettings");
                           myCookie.Expires = DateTime.Now.AddDays(-1d);
                           Response.Cookies.Add(myCookie);
                           Label1.Text = "submit button is press";
    
                        }
                        else
                        {
                           _loginSet = false;
    
                        }
                    }
                    catch (Exception Exception)
                    {
                        Context.Trace.Warn(Exception.Message);
                        Global.ErrorMessage(Exception.Message, Context);
                     _loginSet = false;
    
                    }
    
               }
            }
