    public class SomeObject
    {
        string id;
        DateTime date;
        public string ID
        {
            get { return id; }
            set {
                id = value;
                UpdateDB();
            }
        }
        public DateTime Date
        {
            get { return date; }
            set {
                date = value;
                UpdateDB();
            }
        }
        private void UpdateDB() {
            // Make some SQL, and work with your DB.
            // You maybe want to send arguments to this method about what has to be updated.
        }
    }
