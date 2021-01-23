    [WebMethod]
    public CascadingDropDownNameValue[] GetMakes(string knownCategoryValues)
    {
        string query = "SELECT MakeName, MakeId FROM Makes";
        List<CascadingDropDownNameValue> Makes = GetData(query);
        return Makes.ToArray();
    }
 
    [WebMethod]
    public CascadingDropDownNameValue[] GetModels(string knownCategoryValues)
    {
        string make = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["MakeId"];
        string query = string.Format("SELECT ModelName, ModelId FROM Models WHERE MakeId = {0}", make);
        List<CascadingDropDownNameValue> Models = GetData(query);
        return Models.ToArray();
    }
