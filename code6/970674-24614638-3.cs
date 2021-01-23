    class Person : IIntroductionBehavior
    {
        public String Name { get;set; }
        public Int32 Age { get;set; }
        public Person(){
            Name = "over";
            Age = 9000;
        }
        public void Introduce()
        {
            Console.WriteLine("I'm " + Name + " and I am " + Age + " years old");
        }
    }
