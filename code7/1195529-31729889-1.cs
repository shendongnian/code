    using (MhEntities DContext = new MhEntities())
    {
        string res = DContext.Database.SqlQuery<string>("SELECT MoneyforHealthEntities.Fn_LEVEL0_Acount_Id(@p0)", Account_Id).FirstOrDefault();
        return Convert.ToInt64(res);
    }
