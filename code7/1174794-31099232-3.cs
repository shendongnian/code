        Stopwatch spw = new Stopwatch();            
        int stepNo = 0;
        while (!haltWork)
        {
            Thread.Sleep(100);
            switch (stepNo)
            {
                case 0:
                    TalkToSerialPort1();
                    spw.Restart();
                    stepNo += 1;
                    break;
                case 1:
                    if (spw.Elapsed.Hours >= 3)
                    {
                        TalkToSerialPort2();
                        spw.Restart();
                        stepNo += 1;
                    }
                    break;
                case 2:
                    if (spw.Elapsed.Hours >= 1)
                    {
                        TalkToSerialPort3();
                        spw.Restart();
                        stepNo += 1;
                    }
                    break;
                // etc...
            }
        }
