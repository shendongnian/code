    string s = "int my variable string some other variable";
    string[] sarr1 = new string[] { "string" };
    string[] sarr=s.Split(sarr1, StringSplitOptions.None);
    for (int i = 0; i < sarr.Length; i++)
    {
        if (i == sarr.Length - 1)
            Console.WriteLine(sarr1[0] + sarr[i]);
        else
            Console.WriteLine(sarr[i]);
    }
