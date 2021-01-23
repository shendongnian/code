    class Person
    {
        private readonly SharedValue<string> name = new SharedValue<string>();
        private readonly SharedValue<Int32> age = new SharedValue<Int32>();
        
        public String Name { get {return name.Value;} set {name.Value = value;} }
        public Int32 Age { get {return age.Value;} set {age.Value = value;} }
        public IIntroductionBehavior introBehavior{get;set;}
        public Person(){
            Name = "over";
            Age = 9000;
            introBehavior = new IntroductionBehavior(name, age); // note that we pass the SharedValues
        }
    }
    class IntroductionBehavior : IIntroductionBehavior
    {
        SharedValue<String> Name;
        SharedValue<Int32> Age;
        public IntroductionBehavior(SharedValue<string>  name, SharedValue<int> age){
            Age = age;
            Name = name;
        }
        public void Introduce(){
            Console.WriteLine("I'm " + Name.Value + " and I am " + Age.Value + " years old");
        }
    }    
