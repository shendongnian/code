    public class People {
        public int Id { get; set; }
        private string _name;
        public string Name {
            get { return _name + " | " + Id; }
            set { _name = value; }
        }
        public List<People> Children { get; set; }
        public People() {
            Children = new List<People>();
        }
    }
