    var lForm = await context.Request.ReadFormAsync();
                        if (!String.IsNullOrEmpty(lForm["input_login"]) && !String.IsNullOrEmpty(lForm["input_pass"]))
                        {
                            //Benutzer authentifizieren
                            var lAuthenticatedUser = new UserManager().Authenticate(lForm["input_login"], lForm["input_pass"]);
                            if (lAuthenticatedUser != null)
                            {
                                //Existiert der Nutzer legen wir die Claims an
                                ClaimsIdentity lIdentity = new ClaimsIdentity(lOptions.AuthenticationType);
                                lIdentity.AddClaim(new Claim(ClaimTypes.Name, lAuthenticatedUser.Username));
                                lIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, lAuthenticatedUser.InternalUserId.ToString()));
                                lIdentity.AddClaim(new Claim(ClaimTypes.SerialNumber, context.Request.RemoteIpAddress));
                                //Und zum Schluss einloggen
                                context.Authentication.SignIn(lIdentity);
                                
                                //Und auf die Spieleseite weiterleiten
                                context.Response.Redirect(BLL._Configuration.HinagGameURL);
                            }
                        }
