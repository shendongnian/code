    string[] lineCounter=new string[]{
    "1.ExampleFirst\n",
    "  SomeText\n",
    "  SomeOtherText\n",
    "  FinalLine\n",
    "\n",
    "2.ExampleSecond\n",
    "  SomeText\n",
    "  SomeOtherText\n",
    "  FinalLine\n",
    "\n"
    };
    int v = 0;
    int s = 0;
    
    while (s < lineCounter.Count())
    {
        if (int.TryParse(lineCounter[s].Substring(0, 1), out v) == true && lineCounter[s] != "\n")
        {
            int m = int.Parse(lineCounter[s].Substring(0, 1));
            Console.WriteLine(lineCounter[s].Remove(0, lineCounter[s].IndexOf(".")).Insert(0, (m - 1).ToString()));
        }
        else
            Console.WriteLine(lineCounter[s]);
        s++;
    }
