    using System;
    using System.Reflection;
    
    public class Example
    {
       // Mark OldProperty As Obsolete.
       [ObsoleteAttribute("This property is for future use", false)] 
       public static string OldProperty
       { get { return "The old property value."; } }
    
       public static string NewProperty
       { get { return "The new property value."; } }
    
       // Mark CallOldMethod As Obsolete.
       [ObsoleteAttribute("This method is for future use", true)] 
       public static string CallOldMethod()
       {
          return "You have called CallOldMethod.";
       }
    
       public static string CallNewMethod() 
       {   
          return "You have called CallNewMethod.";
       }   
    
       public static void Main()
       {                 
          Console.WriteLine(OldProperty);
          Console.WriteLine();
          Console.WriteLine(CallOldMethod());
       } 
    }
    // The attempt to compile this example produces output like the following output:
    //    Example.cs(31,25): error CS0619: 'Example.CallOldMethod()' is obsolete: 
    //            'This method is for future use'
    //    Example.cs(29,25): warning CS0618: 'Example.OldProperty' is obsolete: 
    //            'This property is for future use'
