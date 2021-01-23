    abstract class Position
    {
    	public abstract string Title { get; }
    }
    
    class Manager : Position
    {
    	public Manager(string department) { }
    	public override string Title => "Manager";
    }
    
    class Clerk : Position
    {
    	public override string Title => "Clerk";
    }
    
    class Programmer : Position
    {
    	public Programmer(string language) { }
    	public override string Title => "Programmer";
    }
