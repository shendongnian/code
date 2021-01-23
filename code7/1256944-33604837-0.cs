    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
        struct element
        {
          public    string name;
          public string sex;
          public int numComp;
        } ;
    	public static void Main()
    	{
    		string input = "Jervie, 12, M , Jaimy ,11, F, Tony , 23, M ,Janey , 11, F";
    		var elements = input.Split(',').Where(x => !string.IsNullOrWhiteSpace(x))
    										.Select(x => x.Trim()).Chunk(3)
    										.Select(x =>
    												{
    													var i = x.ToList();
    													return new element
    													{
    														name = i[0],
    														numComp = int.Parse( i[1]),
    														sex = i[2],
    													};
    												});
    		var sorted = elements.OrderBy(x => x.numComp).ToList();
    		var temp = sorted.Select(x => x.name + ", " + x.numComp+", " + x.sex  );
    		var output =  string.Join(", ",temp);
    		Console.WriteLine(output);
    	}
    }
    
    public static class LinqExtension
    {
    	public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            while (source.Any())
            {
                yield return source.Take(chunksize);
                source = source.Skip(chunksize);
            }
        }
    }
