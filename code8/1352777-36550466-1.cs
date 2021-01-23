    string Text = "012345678901234567890123456789";
    List<int> Indexes = new List<int>() { 2, 4, 7, 9, 15, 18, 23, 10, 1, 2, 15, 40 };
    HashSet<int> hashSet = new HashSet<int>(Indexes);
    StringBuilder sb = new StringBuilder(Text.Length);
    for (int i = 0; i < Text.Length; ++i)
    {
        if (!hashSet.Contains(i))
        {
            sb.Append(Text[i]);
        }
    }
    string str = sb.ToString();
