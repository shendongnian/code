    ForeClass = new Test_Onchange();
    ForeClass.ValueChanged += new EventHandler(EventValueChanged);
    for (int i = 0; i < 10; i++)
    {
        Random Rndvalue = new Random();
        int RandVal = Rndvalue.Next(0, 100);
        ForeClass.Value = RandVal;
        System.Threading.Thread.Sleep(500);           
    }
