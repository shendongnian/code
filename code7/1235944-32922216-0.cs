    public static class StringExtensions {
	    public static string DistinctFrom(this string one, string two) {
		    return new string(one.Except(two).ToArray());	
	    }
    }
    //Usage. Given 'ABC' and 'BC' results 'A'
    var distinctString = str1.DistrinctFrom(str2);
