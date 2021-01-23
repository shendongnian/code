            public ApplicationUserManager UsrMan = new ApplicationUserManager(new ApplicationUserStore(new libProduccionDataBase.Contexto.DataBaseContexto()));
            public void CheckLogin( bool change = false )
            {
                using (var loginfrm = new LogInForm())
                {
                    if (loginfrm.ShowDialog() == DialogResult.OK)
                    {
                        var t = Auxiliares.Validate(loginfrm.Response);
                        if (t.isValid &&
                            UsrMan.FindByName( loginfrm.Response.UserName ) != null &&
                            UsrMan.CheckPassword( UsrMan.FindByName( loginfrm.Response.UserName ), loginfrm.Response.Password )
                        )
                        {
                            Program.User = UsrMan.FindByName( loginfrm.Response.UserName );                            
                        }
                        else
                        {
                            if (!t.isValid)
                            {
                                var str = new System.Text.StringBuilder();
                                t.Result.ToList().ForEach( err =>
                                {
                                    str.AppendFormat( "• {0}\n", err.ErrorMessage );
                                } );
                                MessageBox.Show( str.ToString(), "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error );
                            }
                            CheckLogin();
                        }
                    }
                    else
                    {
                        if (!change) ExitThread();
                    }
                }
            }
