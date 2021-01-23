    public class Users
    {
        public int ID { get; set; }
        public string TCKN { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
    }
    public class Root
    {
        public List<User> Users {get;set;}
    }
    var root = new Root { Users = mydb.Kullanicilars.ToList() };
    
    JsonConvert.SerializeObject(root);
