    [HttpPost]
    public string SaveDefCompny(string serializeddata)
    {
       DefCompanyDTO product = NewtonSoft.JsonConvert.DeSerializeObject(serializeddata);
    }
