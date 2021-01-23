    public void DoSomething(string bigString)
    {
       string st1 = bigString;
       string[] st2 = st1.Split('.');
       string t1 = st2[st2.Length - 1];
       string t2 = st2[st2.Length - 2];
       string msg = string.Join(".", st2.Take(st2.Length-2));    
       Console.WriteLine(t1);
       Console.WriteLine(t2);
       Console.WriteLine(msg);
    }    
