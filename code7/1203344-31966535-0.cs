    string s = "112233";
    
    List<string> parts = new List<string>(s.Length / 2);
    for (int i = 0; i < s.Length; i += 2)
    	parts.Add(s.Substring(i, 2));
    
    Console.WriteLine(string.Join("-", parts)); // 11-22-33
