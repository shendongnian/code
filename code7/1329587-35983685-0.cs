     [CustomAction]
        public static ActionResult CreateIisConfigs(Session session)
        {
            try
            {
                LoadXmlFile(session);
                var iisSettings = new IisSettings
                {
                    PathName = session["PATHNAME"],
                    UserPath = session["USERPATH"],
                    Website = session["WEBSITE"],
                    SqlDataSource = session["BLOBSQLDATASOURCE"],
                    AppPool = session["BLOBAPPLICATIONPOOL"],
                    ApplicationName = session["BLOBAPPLICATION"],
                    ApplicationPath = @"Sites\Blabla.Application.WebAPI.Blobs",
                    EnvirName = session["BLOBENVIRONMENTNAME"],
                    EnvirPath = session["ENVIRONMENTPATH"],
                    IdentityDomainType = session["BLOBIDENTITYDOMAIN"],
                    SitePhysPath = session["SITEPHYSPATH"],
                    SqlPass = session["BLOBSQLPASSWORD"],
                    SqlUser = session["BLOBSQLUSER"],
                    SslCertPath = session["SSLCERTPATH"],
                    SslCertPass = session["SSLCERTPASS"],
                    UserAppl = session["BLOBUSERAPPLICATION"],
                };
                IisConfigs.ApplyNewConfigs(iisSettings);
            }
            catch (Exception e)
            {
                session.Log("----------------------------------------IIS ERROR ---------------------------------------");
                session.Log(e.ToString());
                return ActionResult.Failure;
            }
            return ActionResult.Success;
        }
