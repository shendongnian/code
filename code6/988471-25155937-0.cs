    public delegate void delgJournalBaseModified(string a);
    public class User
    {
        public string id, name, email, image;
        public User(string uid,string uName)
        {
            id = uid;
            name = uName;
            Console.WriteLine(this.name);
            Console.WriteLine(this.email);
            GetEmail();
        }
        private void GetEmail()
        {
            set(delegate(string d)
            {
                this.email = d;
            }); 
        }
        private void set(delgJournalBaseModified delgJournalBaseModified)
        {
            delgJournalBaseModified.Invoke("value is set");
            Console.WriteLine(this.email);
          
        } 
    }
