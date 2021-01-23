    public class MyClass 
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public MyClass Copy()
        { 
            return new MyClass
            {
                ID = this.ID,
                Name = this.Name
            };
        }
    }
