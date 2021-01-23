    ArrayList col1 = new ArrayList();
    ArrayList col2 = new ArrayList();
    ArrayList col3 = new ArrayList();
    using (StreamReader sr = new StreamReader(@"Sample.txt"))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] split = Regex.Split(line, @"\s+");
    
            if (split.Count() == 3)
            {
                col1.Add(Convert.ToInt32(split[0]));
                col2.Add(Convert.ToInt32(split[1]));
                col3.Add(Convert.ToInt32(split[2]));
            }
        }
    }
    // sort all columns
    col1.Sort();
    col2.Sort();
    col3.Sort();
    
    // output is largest to smallest so invert sort
    for (int i = col1.Count -1 ; i >= 0; i--)
    {
        Console.WriteLine(string.Format("{0}\t{1}\t{2}", col1[i], col2[i], col3[i]));
    }
