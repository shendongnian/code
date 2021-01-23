     //processes
                if (score < 0 || score > 1000)
                {
                    Console.WriteLine("Invalid Score");
                }
                else
                {
                    percent = score/1000;
    
                    if (percent >= .9)
                    {
                        grade = "A";
                    }
                    else if (percent >= .8)
                    {
                        grade = "B";
                    }
                    else if (percent >= .7)
                    {
                        grade = "C";
                    }
                    else if (percent >= .6)
                    {
                        grade = "D";
                    }
                    else
                    {
                        grade = "F";
                    }
