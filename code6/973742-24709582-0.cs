                System.Timers.Timer testTimer = new System.Timers.Timer();
                testTimer.Enabled = true;
                //testTimer.Interval = 3600000; //1 hour timer
                testTimer.Interval = 100000;// Execute timer every // five seconds
                testTimer.Elapsed += new System.Timers.ElapsedEventHandler(FillGrid);
