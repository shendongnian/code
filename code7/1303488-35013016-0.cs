    public static class BLah
    {
    	public static string DoTrim(this string item)
    	{
    		Console.WriteLine("called");
    		return item.Trim();
    	}
    }
    IList<string> items = new List<string> { "a", "b", "c" };
    items.Where(o => o.Contains(term.DoTrim()));
