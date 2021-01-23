    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public dynamic Details { get; set; }
        public User()
        {
            Details = new ExpandoObject();
        }
        public void AddSingleDetail(string key, string value)
        {
            var dict = this.Details as IDictionary<string, Object>;
            if (dict.ContainsKey(key))
            {
                dict[key] += "," + value;
            }
            else
            {
                dict[key] = value;
            }
        }
        public void AddDetails(object detailsObject)
        {
            var type = detailsObject.GetType();
            foreach (var prop in type.GetProperties())
            {
                AddSingleDetail(prop.Name, prop.GetValue(detailsObject).ToString());
            }
        }
    }
