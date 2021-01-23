    [Flags]
    public enum Day
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64,
    }
    Day d = Day.Friday | Day.Saturday;
    Console.WriteLine(d);
    Console.WriteLine((int)d);
