    [ScriptService]
    public class CascadingDropdown1 : System.Web.Services.WebService
    {
        [WebMethod]
        public CascadingDropDownNameValue[] GetMakes(string knownCategoryValues)
        {
            string query = "exec spIBCInventorySearch_MAKE @IDCustomer = 253433";
            List<CascadingDropDownNameValue> Makes = GetData(query);
            return Makes.ToArray();
        }
    
    [WebMethod]
    public CascadingDropDownNameValue[] GetModels(string knownCategoryValues)
    {
        string make = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["MakeId"];
        string query = string.Format("exec spIBCInventorySearch_MODEL @VehicleMake = {0}, @IDCustomer = 253433 ", make);
        List<CascadingDropDownNameValue> Models = GetData(query);
        return Models.ToArray();
    }
    
    private List<CascadingDropDownNameValue> GetData(string query)
    {
        string conString = ConfigurationManager.ConnectionStrings["UID=pal;Password=123;DATABASE=ATDBSQL;"].ConnectionString;
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
                        value = reader[0].ToString()
                    });
                }
                reader.Close();
                con.Close();
                return values;
            }
        }
    }
