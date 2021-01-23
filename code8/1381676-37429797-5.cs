    public class Visitor
    {
    	public void doItterate(Cat c)
    	{
    		Console.WriteLine(c.ToString());
    		c.makeNoise();
    		c.climbTree();
    	}
    
    	public void doItterate(Dog d)
    	{
    		Console.WriteLine(d.ToString());
    		d.makeNoise();
    	}
    }
    
    public abstract class Pet
    {
    	public Pet(string name, int age, Mood mood)
    	{
    		this.MoodOfPet = mood;
    		this.Name = name;
    		this.Age = age;
    	}
    
    	public string Name
    	{
    		get;
    		private set;
    	}
    
    	public int Age
    	{
    		get;
    		private set;
    	}
    
    	public Mood MoodOfPet
    	{
    		get;
    		private set;
    	}
    
    	public abstract void makeNoise();
    	public override string ToString()
    	{
    		return this.Name + " is " + this.Age +
                " years old  and feels " + this.MoodOfPet;
    	}
    
    	public abstract void accept(Visitor v);
    }
    
    public enum Mood
    {
    	Surly,
    	Happy
    }
    
    public abstract class Dog : Pet
    {
    	public Dog(string name, int age, Mood mood): base (name, age, mood)
    	{
    	}
    
    	public override void makeNoise()
    	{
    		Console.WriteLine(this.Name + " is woofing");
    	}
    
    	public override void accept(Visitor v)
    	{
    		v.doItterate(this);
    	}
    }
    
    public class SheepDog : Dog
    {
    	public SheepDog(string name, int age, Mood mood): base (name, age, mood)
    	{
    	}
    }
    
    public class Cat : Pet
    {
    	public Cat(string name, int age, Mood mood): base (name, age, mood)
    	{
    	}
    
    	public void climbTree()
    	{
    		Console.WriteLine(this.Name + " is climbing");
    	}
    
    	public override void makeNoise()
    	{
    		Console.WriteLine(this.Name + " is meowing");
    	}
    
    	public override void accept(Visitor v)
    	{
    		v.doItterate(this);
    	}
    }
    
    public class Terrier : Dog
    {
    	public Terrier(string name, int age, Mood mood): base (name, age, mood)
    	{
    	}
    
    	public void growl()
    	{
    		Console.WriteLine(this.Name + " is growling");
    	}
    
    	public override void makeNoise()
    	{
    		growl();
    	}
    }
    
    public class MyPets
    {
    	private Visitor visitor = new Visitor();
    	public MyPets()
    	{
    		Pets = new List<Pet>();
    	}
    
    	public List<Pet> Pets
    	{
    		get;
    		private set;
    	}
    
    	public void addPet(Pet p)
    	{
    		Pets.Add(p);
    	}
    
    	public void itterate()
    	{
    		foreach (Pet p in Pets)
    		{
    			p.accept(visitor);
    		}
    	}
    }
