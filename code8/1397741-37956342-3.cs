    //code above, plus
    private static int InstanceCounter { get; set; }
    private static readonly object counterLock = new object();
    public InstanceCountingPerson(string name, int age) {
        Name = name;
        Age = age;
        lock (counterLock) // safe property access
        {
            InstanceCounter++;
            // and whatever else you have to do with the lock enabled
        }
    }
