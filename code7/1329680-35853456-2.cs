    //I want to decay the tonnage every 20 seconds
    public void decayTonnage (double tonnage)
    {
            while (true)
            {
                lock(x)
                {
                    tonnage = tonnage - 160;
                }
                Thread.Sleep(20000);
            }
    }
    //Add to the tonnage every 10 seconds
    public void addTonnage (double tonnage)
    {
            Random random = new Random();
            while (true)
            {
                double randomNumber = random.Next(97, 102);
                lock(x)
                {
                    tonnage = tonnage + randomNumber;
                }
                Thread.Sleep(10000);
            }
    }
