    class MyClass {
    	private int myProperty;
    	// Declare MyProperty. 
    	public int MyProperty {
    		get {
    			return myProperty;
    		}
    		set {
    			myProperty = value;
    		}
    	}
    }
    public class MyTypeClass {
    	public static void Main(string[] args) {
    		try {
    			// Get the Type object corresponding to MyClass.
    			Type myType = typeof(MyClass);
    			// Get the PropertyInfo object by passing the property name.
    			PropertyInfo myPropInfo = myType.GetProperty("MyProperty");
    			// Display the property name.
    			Console.WriteLine("The {0} property exists in MyClass.", myPropInfo.Name);
    			
    			// Instantiate MyClass
    			var myObject = new MyClass()
    			{
    			    MyProperty = 5
    			};
    			
    			// Get value using reflection
    			Console.WriteLine("My property value for my object is {0}.", myPropInfo.GetValue(myObject));
    			
    		} catch (NullReferenceException e) {
    			Console.WriteLine("The property does not exist in MyClass." + e.Message);
    		}
    	}
    }
