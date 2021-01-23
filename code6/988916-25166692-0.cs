    var buffer1 = new List<int>();
    foreach (string item in lines1)
    {
        buffer1.AddRange(item.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
    }
