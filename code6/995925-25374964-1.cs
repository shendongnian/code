    foreach (string i in numberArray.Distinct())
    {
        int x = Int32.Parse(i);
        if (x % 2 == 0)
        {
            ListBox1.Items.Add(i);
        }
    }
