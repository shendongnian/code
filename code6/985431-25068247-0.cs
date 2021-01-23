    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    	}
    	
    	  private void GenericMethod<T, U>() 
            where T : Block
            where U : IBlock
        {
            var list = new List<T>();
    
            // this casting works
            var item = new Block();
            var iItem = (IBlock)item;
    
    	    // cast your iterator
            foreach (IBlock l in list)
            { 
                // this compiles but you don't need it anymore
                // var variable = (U)l;
            }
        }
    	
    	public interface IBlock
    	{}
    	public class Block : IBlock
    	{}
    }
