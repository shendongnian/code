    public class Main_data
    {
        public string username { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    
        public string GetSortBy(string sortBy)
        {
            switch (sortBy)
            {
                case "username": return username;
                case "name": return name;
                case "address": return address;
                default:
                    throw new NotSupportedException(
                        String.Format("Cannot sort on {0}", sortBy));
            }
        }
    }
    
    public class DataBinder
    {
        public void BindData()
        {
            string sortBy       = Request.QueryString["SortBy"];
            string sortOrder    = Request.QueryString["SortOrder"];
    
            IEnumerable<KeyValuePair<Main_key, Main_data>> records = null;
            if (sortOrder = "Asc")
            {
                records = mainTable.OrderBy(key=> key.Value.GetSortBy(SortBy);
            }
            else if (sortOrder == "Desc")
            {
                records = mainTable.OrderByDescending(key=> key.Value.GetSortBy(SortBy);
            }
            else
            {
                throw new NotSupportedException("Unknown sortOrder");
            }
    
            foreach (KeyValuePair<Main_key, Main_data> entry in records)
            {
                // TODO: Do something with the records
            }
        }
    }
