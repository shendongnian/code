        // define objects
        ArrayList Alist = new ArrayList();
        ArrayList Blist = new ArrayList();
        // add elements
        Alist.Add(10);
        Alist.Add(20);
        Alist.Add(30);
        Blist.Add("Y");
        Blist.Add("Z");
        // 
        string Result = string.Empty;
        // accumulate result as: ABABABA with size = 2 * (size of smaller)
        int min = Math.Min(Alist.Count, Blist.Count);
        var j = 0;
        for (int i = 0; i < min; i++)
        {
            Result += Alist[i];
            Result += Blist[i];
			j = i;
        }
        // increment and concatenate the next element of array list A
		++j;
        Result += Alist[j];
        // display result
        Console.WriteLine(Result);
        Console.ReadLine();
