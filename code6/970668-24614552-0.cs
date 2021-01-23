    class IntroductionBehavior : IIntroductionBehavior
    {
        private Person person;
    
        public IntroductionBehavior(Person person){
            this.person = person;
        }
        public void Introduce(){ 
            Console.WriteLine("I'm {0} and I am {1} years old", 
               person.Name, person.Age); // NOTE: use string format
        }
    }
    class Person
    {
        public String Name { get; set; }
        public Int32 Age { get; set; }
        public IIntroductionBehavior introBehavior { get; set; }
        public Person(){
            Name = "over";
            Age = 9000;
            introBehavior = new IntroductionBehavior(this);
        }
    }
