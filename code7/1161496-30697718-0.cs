    while (true)
            {
                int counter = 0;
                if (counter%2==0)
                {
                    Thread.Sleep(5000);
                    counter++;
                    //set ON
                }
                else
                {
                    Thread.Sleep(5000);
                    counter++;
                    //set off
                }
                if (counter==1000)
                {
                    counter -= 1000;
                }
            }
