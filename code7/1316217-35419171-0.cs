    using System;
    using System.Collections.Generic;					
    using System.Text;
    using System.Linq;
    public class Program
    {
	
        public static void Main()
	    {
		
		    var orig = "Item.ObjectA.ObjectBs[Id=1234;Name=Test;Date=12.05.2016 11:11:11].ObjectD.Value";
		
		    var parts = new List<string>();
		    var stop = false;
		    var current = new StringBuilder();
		
		    for (int i = 0; i < orig.Length; i++)
		    {
			
			    if (orig[i] != '.')
			        current.Append(orig[i]);
			
			    if (orig[i] == '[')
			        stop = true;
      		    if (orig[i] == ']')
                    stop = false;
			
			    if ((orig[i] == '.' && !stop) || i == orig.Length - 1)
			    {
			        parts.Add(current.ToString());
				    current.Length = 0;
			    }
				
		
	    	}
		
		    parts.ForEach(x =>  Console.WriteLine(x));
    	}
    }
