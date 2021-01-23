    using (TextWriter tr = new StreamWriter(@"E:\newfiless"))
    {
        foreach (string a in listA)
        {
            tr.WriteLine(a.Trim('"'));
        }
    }
