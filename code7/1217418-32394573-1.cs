     using (YourDbContext dc=new YourDbContext ()){
             Token item = new Token();
             item.tk_date = clientLoginData.LoginTime;
             item.tk_IP = clientLoginData.cl_IP;
             item.tk_ID = clientLoginData.cl_ID;
             item.tk_token = token;
                dc.Tokens.InsertOnSubmit
                dc.SubmitChanges();
       }
