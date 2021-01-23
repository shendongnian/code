	// the unbelievably useful array handling category for games!
	
	public static T AnyOne<T>(this T[] ra) where T:class
		{
		int k = ra.Length;
		int r = UnityEngine.Random.Range(0,k);
		return ra[r];
		}
