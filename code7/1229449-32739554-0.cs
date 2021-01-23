    private string Connectqry(string s)
    {
        if (s == "")
        {
            Console.WriteLine("the query is blank");
        }
        else
        {
            s = s + " , ";
            Console.WriteLine(s);
        }
        return s;
    }
