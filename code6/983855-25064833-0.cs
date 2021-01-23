    public class MySingleton
    {
        // Singleton properties omitted
        private string name;
        public string name
        {
            get{return this.name;}
            set
            {
                if(String.IsNullOrEmpty(this.name))
                    name = value;
                // The exception could be left out, depending on how critical this is
                else
                    throw new exception("The property 'name' can only be set once");
            }
        }
    }
