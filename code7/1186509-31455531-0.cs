    private class EUInput
    {
        public EUInput()
        {
            RtID = 0;
        }
        public int RtID { get; set; }
    }
    //I want to store this class with different RtID values in a list. I tried as below,
    private static void Main(string[] args)
    {
        List<EUInput> list = new List<EUInput>();
        for (int i = 0; i < 5; i++)
        {
            EUInput clsEUInput = new EUInput();
            clsEUInput.RtID = i;
            list.Add(clsEUInput);
        }
        foreach (EUInput obj in list)
        {
            Console.WriteLine(obj.RtID.ToString());
        }
        Console.ReadLine();
    }
