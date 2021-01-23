    var users = new JavaScriptSerializer().Deserialize<List<User>>(json);
---
    public class User
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Job { get; set; }
    }
