        string PlusMinus;
        int rndmTmp1 = Random1();
        int rndmTmp2 = Random2();
        if (rndmTmp1 == 0)
        {
            PlusMinus = hour + ":" + minute + ":" + second + ": " + ampm;
            return PlusMinus;
        }
        else if (rndmTmp1 == 1)
        {
            string temp = hour + ":" + minute + ":" + second +": " + ampm;
            DateTime subtract = DateTime.Parse("2000-01-01 " + temp);
            subtract.AddSeconds(-rndmTmp2);
            PlusMinus = subtract.ToString("h:mm:ss tt");
            return PlusMinus;
        }
        else
        {
