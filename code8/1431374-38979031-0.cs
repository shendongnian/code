    ArrayList Alist = new ArrayList();
        ArrayList Blist = new ArrayList();
        Alist.Add(10);
        Alist.Add(20);
        Alist.Add(30);
        Blist.Add("Y");
        Blist.Add("Z");
        string Result = string.Empty;
        int min = Math.Min(Alist.Count, Blist.Count);
        for (int i = 0; i < min; i++)
        {
            Result += Alist[i];
            Result += Blist[j];
        }
        Console.WriteLine(Result);
        Console.ReadLine();
