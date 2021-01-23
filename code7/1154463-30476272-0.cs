      [HttpGet]
    public List<object> GetAllCompanies2()
    {
        List<object> myCo = DefCompany.AllDefCompany2;
         
        object json = JsonConvert.SerializeObject(myCo);
        return  json;
    }
    
