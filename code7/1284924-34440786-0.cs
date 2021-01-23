    public static void Main(string[] args)
    { 
        // Read program type, default is "1"
        string type = args.Length > 0 ? args[0] : "1";
        switch(type)
        {
            case "1": { Order.RunOrder(); break; }
            case "2": { Shiptment.RunShipment(); break; }
            // ...
        }
    }
