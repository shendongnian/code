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
    private List<CascadingDropDownNameValue> GetData(string query)
    {
       string conString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        SqlCommand cmd = new SqlCommand(query);
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        using (SqlConnection con = new SqlConnection(conString))
        {
            con.Open();
            cmd.Connection = con;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    values.Add(new CascadingDropDownNameValue
                    {
                        name = reader[0].ToString(),
                        value = reader[1].ToString()
                    });
                }
                reader.Close();
                con.Close();
                return values;
            }
        }
    }
