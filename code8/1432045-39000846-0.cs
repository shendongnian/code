    var nums = new List<int>();
    foreach (Match match in Regex.Matches("  1  4 2 5 9 ", @"\d+"))
    {
    	nums.Add(Int32.Parse(match.Value));
    }
    
    ///////////////
    StringBuilder builder = new StringBuilder();
    foreach (int nN in nums)
    {
    	builder.Append(nN).Append(",");
    }
    string result = builder.ToString();
    Console.WriteLine("{0}", result);
