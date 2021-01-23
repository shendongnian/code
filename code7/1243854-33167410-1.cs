    class MyList : ICloneable
    {
        public MyList(int idParam, string nameParam)
        {
            ID = idParam;
            Name = nameParam;
        }
        public object Clone()
        {
            return new MyList(ID, Name);
        }
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
    }
