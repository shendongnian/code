    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var lines = new string[]
    		{
    			"22 The cats of India",
    			"4 Royal Highness",
    			"562 Eating Potatoes",
    			"42 Biscuits in the 2nd fridge",
    			"2 Niagara Falls at 2 PM"
    		};
    		foreach(string line in lines){
    			string search=line.Split(new Char[]{' '})[0];
    			int pos=line.IndexOf(search);
    			string newline = line.Substring(0, pos) + string.Empty + line.Substring(pos + search.Length);
    			Console.WriteLine(newline);
    		}
    	}
    }
