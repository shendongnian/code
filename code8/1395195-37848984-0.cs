    public class Director : Employee
    {
    	//protected string title = "Director";  // shadowing field works here
    
    	public int NumberOfProjectsManaged { get; set; }  // additional property
    
    	public Director() : base() {
    		NumberOfProjectsManaged = 0;
    		title = "Director";
    	} // constructor
    
    	public override void Display()
    	{
    		base.Display();
    		Console.WriteLine("Number of Projects Managed: {0}", NumberOfProjectsManaged);
    	}
    }
