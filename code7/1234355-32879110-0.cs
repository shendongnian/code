    //example.cs
    using System;
    
    public class DoStuff {
    public static void ShowVariable() {
    Console.WriteLine(this.GetType().GetField("_datafile").GetValue(this));
    
    
    //Desired output:
    //Hello world
    
    }
    
    }
