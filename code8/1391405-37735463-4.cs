    foreach (string s in Test())
    {
        System.Diagnostics.Debug.Print(s);
        if (s == "3") break;
    }
    
    string f = Test().First();
