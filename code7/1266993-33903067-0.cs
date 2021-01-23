    public class Program : Action
    {
	 public static void Main()
	 {
		Console.WriteLine("Hello World");
		var command = Console.ReadLine();
		
		//trigger send from Action class
		Action x = new Action();
		x.DoIt(command);
		
		//trigger send from behavior class
        //the lines below are added to show how you can still access the parent behavior, remove or use where appropriate
		Behaviour y = x;
		y.Send();
	 }
    }
    public abstract class  Behaviour 
    {
		public virtual void Send()
		{
			Console.WriteLine("sent");
		}
		
		public virtual void EnableX()
		{
			Console.WriteLine("enabled");
		}
		
		public virtual void Reply()
		{
			Console.WriteLine("replied");
		}
	
		public abstract void DoIt(string type);
    }
    public class Action : Behaviour
    {
	 public override void DoIt(string type)
	 {
		if(type.ToUpper() == "SEND")
			this.Send();
		else if (type.ToUpper() == "ENABLEX")
			this.EnableX();
		else if (type.ToUpper() == "REPLY")
			this.Reply();
		else
			Console.WriteLine("Unknown Command");	
	 }
	
	 new public void Send()
	 {
		Console.WriteLine("Special Sent");
	 }
    }
