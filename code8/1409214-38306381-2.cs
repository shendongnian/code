    public static DateTime Start { get; private set; }
    [STAThread]
    static void Main()
    {
        Start = DateTime.Now;
        //...
    }
