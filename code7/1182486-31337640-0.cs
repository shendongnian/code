    public class Database
    {
        public volatile bool Stop= false;
        public void CreateDb()
        {
            if(!Stop)
            {
               // Create database 
            }
            if(!Stop)
            {
               // Open database
               // Do stuff with database
            }
            
            // blah blah ...
            
            if(Stop)
            {
               // Close your connections
               // Delete your database
            }
        }
    }
    ...
        protected override void OnClosing(CancelEventArgs e)
        {
            Database.Stop = true;
        }
