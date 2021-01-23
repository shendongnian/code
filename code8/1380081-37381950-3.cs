    public class Base<TAnimalType> where TAnimalType : Animal
    {
    	public virtual TAnimalType MyAnimal { get; set; }
    }
    
    public class Derived : Base<Dog>
    {
    	public override Dog MyAnimal { get; set; }
    }
