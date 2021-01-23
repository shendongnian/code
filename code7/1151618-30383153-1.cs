    public class myClass
    {
        public int myColumn { get; set; }
        public string myColumn2 { get; set; }
    }
    public string MySqlMethod()
        {
            using (var conn = new SqlConnection("connectionString"))
            {
                var query = "SELECT * FROM SomeTable;";
                var cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var listToConvert = new List<myClass>();
                while (dr.Read())
                {
                    var toAdd = new myClass();
                    toAdd.myColumn = dr.GetInt32(dr.GetOrdinal("myColumn"));
                    toAdd.myColumn2 = dr.GetString(dr.GetOrdinal("myColumn2"));
                    listToConvert.Add(toAdd);
                }
                return GenerateJson(listToConvert);
            }
        }
    public static string GenerateJson<T>(List<T> obj)
        {
            var returnString = "[";
            var listCounter = 0;
            foreach (var item in obj)
            {
                var counter = 0;
                var props = item.GetType().GetProperties();
                returnString += "{";
                foreach (var prop in props)
                {
                    returnString += "\"" + prop.Name + "\":" + "\"" + prop.GetValue(item, null) + "\"";
                    counter++;
                    if (counter != props.Count())
                        returnString += ",";
                }
                returnString += "}";
                listCounter++;
                if (listCounter != obj.Count())
                    returnString += ",";
            }
            returnString += "]";
            return returnString;
        }
