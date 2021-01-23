    public class Person
    {
        private string _name;
        private int _age;
        //more variables
    
        Person(string name, int age)
        {
            this._name = name;
            this._age = age;
        }
        public int GetAge()
        {
            return age;
        }
        //... more getters. NOTE there is a way of doing this called "Accessors"
        public int Age { get; set; }
    }
