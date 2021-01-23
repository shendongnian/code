    public class Parent { };          // Should output "Parent"
    public class ChildA : Parent { }; // Should output "Child A"
    public class ChildB : Parent { }; // Should output "Not working yet"
    public class ChildC : Parent { };
    
    public class Program
    {
    	public static void Main()
    	{
    		var commands = new List<Parent>() { new ChildA(), new ChildB(), new Parent(), (ChildA)null};
    		Console.WriteLine(string.Join(", ", commands.Select(c => c.Run())));
    		
    		// extension method can be invoked for null
    		Console.WriteLine(((ChildA)null).Run());
    		
    		//// crashes on (ChildA)null with error: 
    		//// The call is ambiguous between the following methods or properties: 'Extensions.Run(ChildA)' and 'Extensions.Run(ChildC)'
    		//Console.WriteLine(string.Join(", ", commands.Select(c => Extensions.Run(c as dynamic))));
    	}
    }
