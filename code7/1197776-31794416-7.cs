    public static class LinqExtensions
    {
    	public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, bool> comparer)
    	{
    		return first.Where(x => !second.Any(y => comparer(x, y)));
    	}
    	public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, bool> comparer)
    	{
    		return first.Where(x => second.Any(y => comparer(x, y)));
    	}
    }
    
    class Anime
    {
       public int Id { get; set; }
       public string Title { get; set; }
       public string ImageUrl { get; set; }
    }
    
    void Main()
    {
    	var a1=new Anime[]{new Anime {Id=1,Title="Title1"},new Anime {Id=2,Title="Title2"}};
    	var a2=new Anime[]{new Anime {Id=2,Title="Title2"},new Anime {Id=3,Title="Title3"}};
    
    	var q1=a1.Except(a2,(b1,b2)=>b1.Id==b2.Id);
    	var q2=a2.Except(a1,(b1,b2)=>b1.Id==b2.Id);
    	var q3=a1.Intersect(a2,(b1,b2)=>b1.Id==b2.Id);
    	q1.Dump();
    	q2.Dump();
    	q3.Dump();
    }
