    public MainWindow()
        {
            ....
            MongoManagement mm = new MongoManagement();
            mm.Connect();
            foreach (Users user in mm.MongoUsers.FindAll())
            {
                //do something with users data here
            }
