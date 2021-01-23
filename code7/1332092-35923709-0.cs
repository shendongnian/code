    public static void DivideIntoSubStrings(string msg, string methodName, string userId)
    {
        string lengths = String.Format("{0}%{1}%{2}", msg.Length, methodName.Length, userId.Length);
        string st = String.Format("{0}.{1}.{2}.{3}", lengths, msg, methodName, userId);
        DoSomething(st);
    }
    public static void DoSomething(string bigString)
    { 
        string lengthsString = bigString.Split('.').ElementAt(0);
        List<string> lengthsStringArray = lengthsString.Split('%').ToList();
        List<int> lengthIntArray = new List<int>();
        for (int i=0; i < lengthsStringArray.Count; i++)
        {
            lengthIntArray.Add(int.Parse(lengthsStringArray.ElementAt(i))); 
        }
        string msg = bigString.Substring(lengthsString.Length + 1, lengthIntArray.ElementAt(0));
        string methodName = bigString.Substring(lengthsString.Length + msg.Length + 2, lengthIntArray.ElementAt(1));
        string userId = bigString.Substring(lengthsString.Length + msg.Length + methodName.Length + 3, lengthIntArray.ElementAt(2));
        Console.WriteLine(msg);
        Console.WriteLine(methodName);
        Console.WriteLine(userId);
    }
