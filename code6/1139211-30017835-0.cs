    class Animal
    {
        public string Name { get; private set; }
        public Animal(string name)
        {
            Name = name;
        }
        public void MakeSound()
        {
            switch (Name)
            {
            case "Dog":
                Bark();
                break;
            case "Cat":
                Meow();
                break;
            }
        }
        private void Bark() { /* bark implementation goes here */ }
        private void Meow() { /* meow implementation goes here */ }
    }
