    [HttpGet]
    public string GetAllCompanies2()
    {
        List<object> myCo = DefCompany.AllDefCompany2;
         // return myCo----------> works
        string json = JsonConvert.SerializeObject(myCo);
        return  json; ------- > not works conversion error & i need this
    }
