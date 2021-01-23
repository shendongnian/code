    while (true)
    {
        try
        {
            Process[] processesByName = Process.GetProcessesByName("dummy");
            if (processesByName.Length == 1)
            {
                if (Testing.EM(processesByName[0].Id, "a.dll"))
                {
                    processesByName[0].Kill();
                    Thread.Sleep(2000);
                    continue;
                }
                Thread.Sleep(2000);
                if (Testing.EM(processesByName[0].Id, "b.dll"))
                {
                    processesByName[0].Kill();
                    Thread.Sleep(2000);
                    continue;
                }
            }
            Thread.Sleep(2000);
        }
            
        catch (Exception ex)
        {
            Debug.smethod_0("Error! " + ex.Message);
            Thread.Sleep(2000);
        } 
    }
