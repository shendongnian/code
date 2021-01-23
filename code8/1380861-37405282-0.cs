    static Dictionary<string, int> dict = new Dictionary<string, int>();
    static object lockObject = new Object();
    
    public static void IterateOverEachUser()
    {
        lock (lockObject)
        {
            if (dict.Count > 0)
            {
                foreach (KeyValuePair<string, int> item in dict.ToList())
                {
                    string userName = item.Key;
                    int amountLeft = item.Value;
                    if (amountLeft == 60)
                    {
                        Console.WriteLine(userName + " started!");
                    }
                    Console.WriteLine(userName + amountLeft);
                    dict[userName] = dict[userName] - 1;
                    amountLeft = dict[userName];
                    if (amountLeft == 0)
                    {
                        Console.WriteLine(userName + " ran out!");
                    }
    
                    Console.WriteLine("User " + item.Key + " = " + amountLeft);
                }
            }
        }
    }
    
    public static void AddUser(string User)
    {
        if (dict.ContainsKey(User))
        {
            Console.WriteLine("User already exists.");
        }
        else
        {
            dict.Add(User, 60);
            Console.WriteLine("User has been added.");
        }
    }
    
    static void Main(string[] args)
    {
    
        AddUser("U1");
        AddUser("U2");
    
        int counter = 1;
        System.Timers.Timer t1 = new System.Timers.Timer();
        t1.Interval = 5000;
        t1.Elapsed += (oo, ee) => 
        {
            IterateOverEachUser();
            if (counter++ == 5)
                AddUser("U3");
        };
        t1.Start();
    
        Console.ReadKey();
    }
