    public class Database {
        //fake class
        public class databaseEntry
        {
            public Notification myNotification { get; set; }
            private string myStatus { get; private set; }
        }
        //constructor of your DataBase class
        public DataBase(){
            // add fake data to fake database
            myDatabase.Add( new databaseEntry() { myNotification = notification1, myStatus = "approved"});
            myDatabase.Add( new databaseEntry() { myNotification = notification2, myStatus = "pending"});
        }
        // fake notifications
        Notification notification1 = new Notification();
        Notification notification2 = new Notification();
        // fake database of type databaseEntry in List data structure
        List<databaseEntry> myDatabase = new List<databaseEntry>();
    }
