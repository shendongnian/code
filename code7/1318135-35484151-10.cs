    private string jsonObject = JSON_String.Replace("{", "[{").Replace("}", "}]");
    public JsonExample()
            {
                JArray jArray = JArray.Parse(jsonObject);
    
                DataTable dt = new DataTable();
    
                dt.Columns.Add("Name");
                dt.Columns.Add("status");
                dt.Columns.Add("classkey");
    
                foreach (JProperty item in jArray[0])
                {
                    var jArray2 = JArray.Parse(item.Value.ToString());
    
                    foreach (var item2 in jArray2)
                    {
                        dt.Rows.Add(item.Name, item2["status"], item2["classkey"]);
    Console.WriteLine($"Name: {item.Name} Status: {item2["status"]}  classkey {item2["classkey"]} ");
                    }
                } 
            }
