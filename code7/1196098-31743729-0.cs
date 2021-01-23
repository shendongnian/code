    var CurrentVersion = GlobalMethods.GetVersion(dFactory);
                var importedData = await GetImportData();
                _uow.BeginTransaction();
                try
                {
                    foreach (var item in importedData)
                    {
    
                            Account accountData = new Account()
                            {
                                AccountSiebelCode = item.account_code,
                                AccountName = item.account_name,
                                AccountZip = "",
                                CountryID = 1,
                                AccountRegistration = "",//null allowed
                                AccountDisabled = item.account_status != "active" ? true : false,
                                TMID = 0, //Trademark Id
                                AccountAreaNr = "",
                                Audit_User = User.Identity.Name,
                                VersionDataID = CurrentVersion.Item2,
                                VersionAction = "",//Set at Business
                                TokenKey = GlobalMethods.GetTokenAsync().Result
                            };
                            //string contactUserName = "";
    
                            string contactUserName = item.last_name.Replace(" ", "").Count() > 4 ? item.last_name.Replace(" ", "").Substring(0, 4) : item.last_name.Replace(" ", "");
                            contactUserName += item.first_name.Substring(0, 1).ToString();
                            Microsoft.AspNet.Identity.PasswordHasher haspwd= new Microsoft.AspNet.Identity.PasswordHasher();
    
                            Contact contactData = new Contact()
                            {
                                ContactSiebelCode = item.account_code,
                                AccountID = 0, //Account Id
                                ContactFirstName = item.first_name,
                                ContactLastName = item.last_name,
                                ContactTitle = "",
                                ContactType = "",
                                ContactDOB = DateTime.Now, // Dob
                                ContactEmail = item.email,
                                ContactMobile = "",
                                ContactPhone = item.phonenumber,
                                ContactDisabled = false, //contact disabled
                                ContactAppEnabled = true, //contact app enabled
                                UserName = contactUserName, //username
                                //PasswordHash = BCryptEncryption.Encrypt("Gr@fi0ffshore"), //password
                                //PasswordHash = haspwd.HashPassword("Gr@fi0ffshore"), //password
                                PasswordHash ="R1-"+ System.Web.Security.Membership.GeneratePassword(6,1), //password
                                PinCode = "1234", //picode
                                LockOutEnabled = false, //lockout
                                AccessFailedCount = 0, //accessfailedcount
                                Audit_User = User.Identity.Name,
                                VersionDataID = CurrentVersion.Item2,
                                VersionAction = "",//Set at Business
                                TokenKey = GlobalMethods.GetTokenAsync().Result
    
                            };
                            TradeMarketer tradeMarketerData = new TradeMarketer()
                            {
                                TMSiebelCode = item.account_code,
                                TMFirstName = item.trade_marketeer_firstname,
                                TMLastName = item.trade_marketeer_lastname,
                                TMEmail = "",
                                TMAreaNr = item.region,
                                CountryID = 1, //country id
                                Audit_User = User.Identity.Name,
                                VersionDataId = CurrentVersion.Item2,
                                VersionAction = "",//Set at Business
                                TokeyKey = GlobalMethods.GetTokenAsync().Result
                            };
                            _biznessTradeMarketer.Save(tradeMarketerData);
    
                            accountData.TMID = tradeMarketerData.TMID;
                            _biznessAccount.Save(accountData);
    
                            contactData.AccountID = accountData.AccountID;
                            _biznessContact.Save(contactData);
                           
                    }
                    _uow.SaveChanges();
                    _uow.Commit();
                }
                catch (Exception ex)
                {
                    _uow.Rollback();
                    ModelState.AddModelError("", ex.InnerException);
                }
