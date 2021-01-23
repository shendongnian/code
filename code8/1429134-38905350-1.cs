    public class Database {
    // fake class 
    public class databaseEntry
    {
        public Notification myNotification { get; set; }
        private string myStatus { get; private set; }
    }
    // fake notifications
    Notification notification1 = new Notification();
    Notification notification2 = new Notification();
    // fake database of type databaseEntry in List data structure
    List<databaseEntry> myDatabase = new List<databaseEntry>();
    public DataBase() 
    {
        // need to do it in the ctor
        // add fake data to fake database
        myDatabase.Add( new databaseEntry(true) { myNotification = notification1, myStatus = "approved"});
        myDatabase.Add( new databaseEntry(false) { myNotification = notification2, myStatus = "pending"});
    }
    public DataBase(bool skip) 
    {
    }
    }
