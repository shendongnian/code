    //Mark the field member as private
    private List<Table1> _Setts1 = new List<Table1>();
    //Use Property to access the field outside of the class
    public List<Table1> Setts1
    {
        get
        {
            if (_Setts1==null || _Setts1.Count()==0) //or any other logic you need
            {   
                //Initialize the field memeber
                _Setts1 = ctx.tblSett1.Where(a => a.CompanyId == companyId).Select(a => a).ToList();
            }
            return _Setts1
        }
    }
