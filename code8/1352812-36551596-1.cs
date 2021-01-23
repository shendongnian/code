    public class Animals
    {
        //fields
        private string name; // <-- You don't need it when you have auto properties
        public Animals(string name)
        {
            Name = name;// <-- Using auto property
        }
        public string Name { get; set; }
        public void Bark()
        {
            Console.WriteLine("{0} said WoWOW", Name);//<-- Using auto property
        }
    }
