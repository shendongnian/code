    foreach (var input in new [] { "BONBON", "ONION", "BBACBB" })
    {
        Console.WriteLine(input);
    	var blocks = GetPalindromeBlocks(input);
    	foreach (var blockList in blocks)
    		Console.WriteLine(string.Concat(blockList.Select(range => "(" + input.Substring(range.Start, range.Length) + ")")));
    }
