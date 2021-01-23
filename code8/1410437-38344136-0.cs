    /// <summary>
    /// Get string value before [first] a.
    /// </summary>
    public static string Before(this string value, string a)
    {
	   int posA = value.IndexOf(a);
   	   if (posA == -1)
	   {
	       return "";
	   }
	   return value.Substring(0, posA);
    }
    var myList = new List<string>();
    foreach var element in array
    {
        myList.Add(element.Before("!!"));
    }
    
    var outPutArray = myList.ToArray();
