    public static class AlternatingExtensions {
    	public static bool IsAlternating<T>(this IList<T> list) where T : IComparable<T>
    	{
    		var diffSigns = list.Zip(list.Skip(1), (a,b) => b.CompareTo(a));
    		var signChanges = diffSigns.Zip(diffSigns.Skip(1), (a,b) => a * b < 0);
    		return signChanges.All(s => s);
    	}
    }
