    public class Dog
    {
        public void Bark() { Console.WriteLine("Woof!"); }
    
        public int NumberOfDogLegs { get { return 2; } }
    
        public int NumberOfDogFriends { get; set; } // this can be set
        private string SecretsOfDog { get; set; } // this is private
    }
    
    public class DoorBell
    {
        public void Chime() { Console.WriteLine("Ding!"); }
    }
