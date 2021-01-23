    static void Main(string[] args)
    {
        //Creation
        List<HumanA> listA = new List<HumanA>();
        for (int j = 0; j < 2000; j++)
        {
            listA.Add(new HumanA());
            listA.Add(new HumanA());
            listA.Add(new HumanA());
            listA.Add(new HumanA());
            listA.Add(new HumanA());
        }
        Stopwatch stop = new Stopwatch();
        List<HumanB> listB = null;
        int roundsToComplete = 10;
        long testTime1 = 0;
        long testTime2 = 0;
        long testTime3 = 0;
        long testTime4 = 0;
        long testTime5 = 0;
        long testTime6 = 0;
        long testTime1ms = 0;
        long testTime2ms = 0;
        long testTime3ms = 0;
        long testTime4ms = 0;
        long testTime5ms = 0;
        long testTime6ms = 0;
        for (int rounds = 0; rounds < roundsToComplete; rounds++)
        {
            //Test 1
            stop.Start();
            listB = new List<HumanB>();
            foreach (HumanA humanA in listA)
            {
                HumanB humanB = new HumanB();
                humanB.age = humanA.age;
                humanB.name = humanA.name;
                humanB.lastName = humanA.lastName;
                listB.Add(humanB);
            }
            stop.Stop();
            testTime1 += stop.ElapsedTicks;
            testTime1ms += stop.ElapsedMilliseconds;
            listB.Clear();
            listB = null;
            stop.Reset();
            //Test 2
            stop.Start();
            listB = new List<HumanB>();
            foreach (HumanA humanA in listA)
            {
                HumanB humanB = new HumanB(humanA);
                listB.Add(humanB);
            }
            stop.Stop();
            testTime2 += stop.ElapsedTicks;
            testTime2ms += stop.ElapsedMilliseconds;
            listB.Clear();
            listB = null;
            stop.Reset();
            //Test 3
            stop.Start();
            listB = listA.ConvertAll(x => new HumanB(x));
            stop.Stop();
            listB.Clear();
            listB = null;
            testTime3 += stop.ElapsedTicks;
            testTime3ms += stop.ElapsedMilliseconds;
            //Test 4
            stop.Start();
            int count = listA.Count;
            listB = new List<HumanB>();
            for (int i = 0; i < count; i++)
            {
                listB.Add(new HumanB(listA[i]));
            }
            stop.Stop();
            listB.Clear();
            listB = null;
            testTime4 += stop.ElapsedTicks;
            testTime4ms += stop.ElapsedMilliseconds;
            //Test 5
            stop.Start();
            listB = listA.Select(x => new HumanB() { name = x.name, lastName = x.lastName, age = x.age }).ToList();
            stop.Stop();
            listB.Clear();
            listB = null;
            testTime5 += stop.ElapsedTicks;
            testTime5ms += stop.ElapsedMilliseconds;
            
            
            //Test6
            stop.Start();
            count = listA.Count;
            listB = new List<HumanB>(count);
            Parallel.For(0, count, c=>
            {
                listB.Add(new HumanB(listA[c])); 
            });
            stop.Stop();
            listB.Clear();
            listB = null;
            testTime6 += stop.ElapsedTicks;
            testTime6ms += stop.ElapsedMilliseconds;
        }
        Console.WriteLine("1: " + testTime1 / roundsToComplete);
        Console.WriteLine("2: " + testTime2 / roundsToComplete);
        Console.WriteLine("3: " + testTime3 / roundsToComplete);
        Console.WriteLine("4: " + testTime4 / roundsToComplete);
        Console.WriteLine("5: " + testTime5 / roundsToComplete);
        Console.WriteLine("6: " + testTime6 / roundsToComplete);
        Console.WriteLine("milliseconds 1: " + testTime1ms / roundsToComplete);
        Console.WriteLine("milliseconds 2: " + testTime2ms / roundsToComplete);
        Console.WriteLine("milliseconds 3: " + testTime3ms / roundsToComplete);
        Console.WriteLine("milliseconds 4: " + testTime4ms / roundsToComplete);
        Console.WriteLine("milliseconds 5: " + testTime5ms / roundsToComplete);
        Console.WriteLine("milliseconds 6: " + testTime6ms / roundsToComplete);
        Console.ReadLine();
    }
