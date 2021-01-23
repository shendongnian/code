    public abstract class Pet : IPet
    {
        public string Name { get; set; }
    
        protected Pet(string name)
        {
            Name = name;
        }
    
        public void Introduce()
        {
            Console.WriteLine($"My name is {Name}. I am a {this.GetType().Name.ToLower()}");
        }
    }
    
    public class Cat : Pet
    {    
        public Cat(string name)
            : base(name)
        {       
        }   
    }
