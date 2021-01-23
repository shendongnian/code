    class Person {
        static void Main(string[] args) {
            Person bart = new Person();
            bart.Name = "Bart";
            Console.ReadKey();
        }
        private string _name;
        public string Name {
            get {
                return _name;
            } set {
                _name = value;
                PropertyChanged(); //no need to fill in `Name` here! :)
            }
        }
        //automatically copy caller's name to `propertyName`, at compile time
        private void PropertyChanged([CallerMemberName] string propertyName = "") {
            object propertyValue = this.GetType().GetProperty(propertyName).GetValue(this);
            Console.WriteLine("Property '" + propertyName + "' changed the value to '" + propertyValue + "'");
        }
    }
