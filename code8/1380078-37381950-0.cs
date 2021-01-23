    void Main()
    {
    	Base myThing = new Derived();
    	//We view it as a Base object, so we can assign any Animal to MyAnimal
    	myThing.MyAnimal = new Cat();
    	
    	//Now let's cast it back to Derived
    	Derived myCastThing = (Derived)myThing;
    	myCastThing.MyAnimal; //We expect a Dog, but we get a Cat?
    }
    
    public class Base
    {
    	public virtual Animal MyAnimal { get; set; }
    }
    
    public class Derived : Base
    {
    	public override Dog MyAnimal { get; set; }
    }
    public class Animal { }
    public class Dog : Animal { }
    public class Cat : Animal { }
