    public class Program
    {
    	public static void Main()
    	{
    		string[] strArr= new string[5] { "1#3", "19#24", "10#12", "13#18", "20#21" };
    		var list = new List<Item>();
    		foreach(var item in strArr){
    			list.Add(new Item(item));
    		}
    		strArr = list.OrderBy(t=>t.Sort).Select(t=>t.Value).ToArray();
    		foreach(var item in strArr)
    			Console.WriteLine(item);
    		
    	}	
    }
    
    public class Item
    {
    	public Item(string str)
    	{
    		var split = str.Split('#');
    		A = Convert.ToInt32(split[0]);
    		B = Convert.ToInt32(split[1]);
    	}
    	public int A{get; set;}
    	public int B{get; set;}
    	
    	public int Sort { get { return Math.Abs(B - A);}}
    	
    	public string Value { get { return string.Format("{0}#{1}",B,A); }}
    }
