    public class Program
    {
	  public static void Main()
	  {
		var structure = new List<List<string>>();
		structure.Add(new List<string>() {"Hello", "World"});
		structure.Add(new List<string>() {"It's", "Me"});
		
		SortBySubIndex(structure, 0);
		SortBySubIndex(structure, 1);
	  }
	
	  public static void SortBySubIndex(List<List<string>> obj, int index) 
	  {
		obj = obj.OrderBy(list => list[index]).ToList();
		Console.WriteLine("INDEX: " + index);
		Console.WriteLine(obj[0][0]);
		Console.WriteLine(obj[1][0]);	
		Console.WriteLine();
	  }
    }
