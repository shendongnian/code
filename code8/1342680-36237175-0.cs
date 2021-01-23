    static void Main(string[] args) {
        Dictionary<string, object> vars = new Dictionary<string, object>();
        vars.Add("Hello", "Hello");
        vars.Add("KeyTwo", 4);
        vars.Add("FloatVal", 8.6f);
        Console.WriteLine("What is the name of the variable?");
        string varname = Console.ReadLine();
        if (vars.ContainsKey(varname))
        {
            Console.WriteLine("What is the new value to set that variable to?");
            Type t = vars[varname].GetType();
            try
            {
                dynamic newval = Convert.ChangeType(Console.ReadLine(), t);
                vars[varname] = newval;
                Console.WriteLine("{0} is now {1}", varname, vars[varname]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("That variable does not exist.");
        }
        Console.ReadKey();
    }
