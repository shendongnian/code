    string String1 = "12345";
    string String2 = "12abc";
    
    var subs = from i in Enumerable.Range(0, String2.Length)
    	from l in Enumerable.Range(1, String2.Length - i)
    	let part = String2.Substring(i, l)
    	select part;
    
    if(subs.Any(s=> String1.Contains(s)))
    {
    	// contains.
    }
