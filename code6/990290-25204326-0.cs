    public CheckType(Vehicle v)
    {
        Train t = v as Train;
        if (t != null)
            Console.Write(t.nrofrailcars);
        else
        {
            Car c = v as Car;
            if (c != null)
                Console.Write(c.nrofwheels);
        }
    }
