    Server srv = new Server(@"server\instance");
            ServerConnection conContext = new ServerConnection();
            conContext = srv.ConnectionContext;
            conContext.LoginSecure = false;
            conContext.Login = "user";
            conContext.Password = "passw";
            Server srv2 = new Server(conContext);
    
            Database db;
            db = srv2.Databases["mydb"];
           
            StoredProcedure sp = db.StoredProcedures["spMySP"];
            sp.TextMode = false;
            sp.AnsiNullsStatus = true;
            sp.QuotedIdentifierStatus = true;
    
            
            sp.TextBody = SPBody;
            try
            {
                sp.Alter();
            }
    
            catch (SqlServerManagementException ex)
            { 
           
            
            }
