    protected void Login_Click(object sender, EventArgs e)
            {
                bool Testsuccessfullogin = false;
                if (Testsuccessfullogin)
                {
                    //Your code after successfull login
                }
                else
                {
                   //Invalid Login --- Capture Each login event based on IP
                    string strIp;
                    strIp = Request.ServerVariables["HTTP_X_FORWARDED_FOR"]; //when user is behind proxy server
                    if (strIp == null)
                    {
                        strIp = Request.ServerVariables["REMOTE_ADDR"];//Without proxy
                    }
    
                    List<InvalidLogin> user = null;
                    if (HttpContext.Current.Application["Users"] == null) //Adding List to Application State
                    {
                        user = new List<InvalidLogin>();
                    }
                    else
                    {
                        user = (List<InvalidLogin>)HttpContext.Current.Application["Users"];
                    }
                    var remove = user.RemoveAll(x => x.Attempttime < DateTime.Now.AddMinutes(-15));//Remove IP Before 15 minutes(Give 15 Min Time Next Login)
                    var checkLogged = user.Find(x => x.IP == strIp);
                    if (checkLogged == null)
                    {
                        user.Add(new InvalidLogin
                        {
                            IP = strIp,
                            Attempttime = DateTime.Now,
                            AttemptCount = 1
    
                        });
                         Application.Lock();
                         HttpContext.Current.Application["Users"] = user;
                          Application.UnLock();
                    }
                    else
                    {
                        if (checkLogged.AttemptCount < 4)
                        {
                            checkLogged.Attempttime = DateTime.Now;
                            checkLogged.AttemptCount++;
                            Application.Lock();
                            HttpContext.Current.Application["Users"] = user;
                            Application.UnLock();
                        }
                    }
    
    
                    
                    if (checkLogged != null)
                    {
                        if (checkLogged.AttemptCount > 3)
                        {
                            captcha.Visible = true;  //Showing captcha 
                        }
                    }
    
    
    
    
                }
            }
