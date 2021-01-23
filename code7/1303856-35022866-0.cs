    class Animal
    {
        public string name { get; set; } //make these properties. 
        public int age { get; set; }
        public int count { get; set; }
        //Class Contructors
        public Animal() //Default Constructor
        {
            name = "Oz";
            age = 6;
            count++;
        }
        public Animal(string _name, int _age)
        {
            name = _name;
            age = _age;
        }
        //Class Methods
        public void Print()
        {
            MessageBox.Show("Name: " + name);
        }
    }
