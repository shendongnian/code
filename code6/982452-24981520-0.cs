    public class MongoManagment
    {
        public MongoCollection<Users> MongoUsers {get; set;}
        public void Connect()
        {
            ....
            this.MongoUsers = database.GetCollection<Users>("user");
        }
