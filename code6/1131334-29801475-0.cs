            int timeout = 10000;
            int cycleWait = 1000;
            for (int i = 0; i < timeout / cycleWait; i++)
            {
                try
                {
                    string data = mbSession.Query(":TRAC:DATA?");
                    break;
                }
                catch
                {
                    Thread.Sleep(cycleWait); 
                }
            }
