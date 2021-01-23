    public class MyClass
    {
        private int id;
        public MyClass(MyClass instance)
        {
            this.id = instance.ID;
            this.name = instance.Name;
        }
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
    }
