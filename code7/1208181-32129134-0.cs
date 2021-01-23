    public string GetA()
    {
       return "Hello from GetA";
    }
    public string GetB(string id, string all = "")
    {
       if (id.Equals("all") || all.Equals("all"))
       {
           return "Hello all from GetB";
       }
       return string.Format("Hello {0} from GetB", id);
    }
