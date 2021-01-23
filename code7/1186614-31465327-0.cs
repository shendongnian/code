    string fname = "xxxxSystemCheckedOutSystemSystemCheckedOutCheckedOut.png";
    Regex RxFname = new Regex( @"(.*?)(System|CheckedOut)+\.png$" );
    
    Match fnameMatch = RxFname.Match( fname );
    if ( fnameMatch.Success )
    {
        Console.WriteLine("Group 0 = {0}", fnameMatch.Groups[0].Value);
        Console.WriteLine("Group 1 = {0}", fnameMatch.Groups[1].Value);
        Console.WriteLine("Last Group 2 = {0}\n", fnameMatch.Groups[2].Value);
        
        CaptureCollection cc = fnameMatch.Groups[2].Captures;
        
        Console.WriteLine("Array and order of group 2 matches (collection):\n");
        for (int i = 0; i < cc.Count; i++)
        {
        	Console.WriteLine("[{0}] = '{1}'", i, cc[i].Value);
        }
    }
