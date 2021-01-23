    public class Dal
    {
        private static object syncObject = new object();
        public static void InsertUpdate(...) 
        {
            lock (syncObject)
            {
                // 1. Get the document type = "inv" , current year and current month,
                // 2. If not found. create a new document type , year and month record with the running number 0001.
                // 3. if found. running + 1.
            }
        }
    }
