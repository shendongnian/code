    abstract class Animal
    {
        public string Name { get; private set; }
        protected Animal(string name)
        {
            Name = name;
        }
        public abstract void MakeSound();
    }
    class Dog : Animal
    {
        public Dog() : base("Dog") { }
        public override void MakeSound() { Bark(); }
        private void Bark() { /* bark implementation goes here */ }
    }
    class Cat : Animal
    {
        public Cat() : base("Cat") { }
        public override void MakeSound() { Meow(); }
        private void Meow() { /* meow implementation goes here */ }
    }
