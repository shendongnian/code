    using (SampleDBDataContext dc = new SampleDBDataContext())
    {
        Token item = new Token();
        item.tk_ID = clientLoginData.cl_ID;
        item.tk_token = token;
        item.tk_date = clientLoginData.LoginTime;
        item.tk_IP = clientLoginData.cl_IP;
        dc.Tokens.InsertOnSubmit(item);
        dc.SubmitChanges();
    }
