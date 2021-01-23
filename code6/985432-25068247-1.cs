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
            var list = new List<U>();
    
            // this casting works
            var item = new Block();
            var iItem = (IBlock)item;
    
    	    // cast your iterator
            foreach (U l in list)
            { 
                
            }
        }
    	
    	public interface IBlock
    	{}
    	public class Block : IBlock
    	{}
    }
