    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string numbers = "1 + 1, 2 - 1, 3 + 3";
    		var newnumber = string.Join(", ",numbers.Split(',')
    			.SelectMany(x => x.Trim().Split(' '))
    			.Select((x,i) => new {Index = i, Value = x })
    			.GroupBy(x => x.Index/3, i => i.Value)
    			.Select(x => {
    				switch(x.ElementAt(1)){
    					case "+": return int.Parse(x.ElementAt(0)) + int.Parse(x.ElementAt(2));
    					case "-": return int.Parse(x.ElementAt(0)) - int.Parse(x.ElementAt(2));
    					case "/": return int.Parse(x.ElementAt(0)) / int.Parse(x.ElementAt(2));
    					case "*": return int.Parse(x.ElementAt(0)) * int.Parse(x.ElementAt(2));
    					default: return 0;
    				}
    			}));
    		Console.WriteLine(newnumber);
    	}
    }
