    public class user
    {
        private string name;
        private string address;
        public user(string name , string address)
        {
            this.name = name;
            this.address= address;
        }
        public string Name
        {
          get { return name; }
          set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        } 
    }
