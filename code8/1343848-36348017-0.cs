    public static DataTable jsonStringToTable(string jsonContent)
            {
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonContent);
                return dt;
            }
