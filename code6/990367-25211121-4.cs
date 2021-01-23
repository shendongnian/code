    using System;
    
    namespace ExclusiveOr
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			char a = ( char )('x' ^ 'y' );
    			char c = 'x', d = 'y';
    			char b = ( char )( c ^ d );
    
    			Console.WriteLine("a = {0}, b = {1}", (int)a, (int)b);
    		}
    	}
    }
