    //Use Property to access the field outside of the class
    public List<Table1> Setts1
    {
        get
        {
            if (_Setts1==null || _Setts1.Count()==0)
            {   
                //Initialize the field memeber
                _Setts1 = ctx.tblSett1.Where(a => a.CompanyId == companyId).Select(a => a).ToList();
            }
            return _Setts1
        }
    }
