    using System.Dynamic;
    string s = "hello world"; //example
    IDictionary<string, object> dynamicArrays = new ExpandoObject();
	
	string[] words = s.Split(' '); //hello, world
    foreach(var word in words)
	{
        dynamicArrays[word] = word.Select(c => new String(new char[] { c })).ToArray();
	}
