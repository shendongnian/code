    public void Generate()
    {
        Create("", 0);
    }
    private string[] names = new[]{ "A", "B", "C" };
    public void Create(string s, int current)
    {
        if (current != 0)
        { 
            s += " and ";
        }
        
        if (current != names.Length)
        {
            string c1 = s + names[current] + " == null"; // case 1
            string c2 = s + names[current] + " != null"; // case 2
            Create(c1, current+1);
            Create(c2, current+1);
        }
        else
        {
            Console.WriteLine(s);
        }
    }
