        static void Main(string[] args)
        {
            Animal cat = new Cat();
            Animal dog = new Dog();
            cat.Eat();
            dog.Eat();
            cat.Move();
            dog.Move();
        }
        public abstract class Animal
        {
            public abstract void Eat();
            protected abstract void ComplexMoving();
            public void Move()
            {
                ComplexMoving();
            }
        }
        public class Dog : Animal
        {
            public override void Eat()
            {
                Debug.WriteLine("Dog says Namnam");
            }
            protected override void ComplexMoving()
            {
                Debug.WriteLine("Dog no stupid");
            }
        }
        public class Cat: Animal
        {
            public override void Eat()
            {
                Debug.WriteLine("Cat says namnam");
            }
            protected override void ComplexMoving()
            {
                Debug.WriteLine("Cat does a slalom");
            }
        }
