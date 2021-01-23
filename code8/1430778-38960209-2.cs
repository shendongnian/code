    public interface IAnimal //this has no behavior at all, it's an interface
    {
        void eat();
        string Name { get; }
    }
    public class Animal //this has a behavior you can modify
    {
        private string m_name;
        public Animal(string name)
        {
            this.m_name = name;
        }
        public void eat()
        {
            Console.WriteLine(m_name + " is eating !");
        }
        public string Name
        {
            get { return m_name; }
        }
    }
    
    public class Cat : Animal //this is your class that changes the behavior 
                              //of the Animal class
    {
    
        public Cat(string name) : base("Cat " + name) //we always need to call 
                                                      //a base constructor
        {
            
        }
        public override void eat() //here we are overriding the eat method
        {
            base.eat(); //calling the Animal eat method
            Console.WriteLine("He is eating fish !"); //editing the methd a bit
        }
        
        //no need to change the behavior of the Name property so we do nothing here
    }
