    namespace TestApp1
    {
        class Program
        {
    
            static void Main(string[] args)
            {
    
                string[] test = GetValues();
                string testView = String.Join(String.Empty, test);
                int rScore = 0;
                int bScore = 0;
    
                GetScore(test,out rScore, out bScore);
    
                string score = "R: " + rScore.ToString() + "  B: " + bScore.ToString();
                Console.WriteLine(testView);
                Console.WriteLine(score);
                Console.ReadLine();
            }
    
            public static void GetScore(string[] test, out int rScore, out int bScore)
            {
                
                int occurence = 0;
                string LastChar = string.Empty;
    
                rScore = 0;
                bScore = 0;
    
                for (int i = 0; i < test.Length; i++)
                {
    
                    if(LastChar == string.Empty)
                    {
                        LastChar = test[i];
                        occurence += 1;
                        continue;
                    }
                    
                    if(LastChar == test[i])
                    {
                        occurence += 1;
    
                        if(i == test.Length - 1)
                        {
                            if (occurence > 1)
                            {
                                if(LastChar == "R")
                                {
                                    rScore += occurence * 2;
                                }
                                else
                                {
                                    bScore += occurence * 2;
                                }
                            }
                        }
    
                    }
                    else
                    {
    
                        if(occurence > 1)
                        {
                            if (LastChar == "R")
                            {
                                rScore += occurence * 2;
                            }
                            else
                            {
                                bScore += occurence * 2;
                            }
                        }
    
                        LastChar = test[i];
                        occurence = 1;
                   
                    }
                     
                }
                
            }
    
    
            public static string[] GetValues()
            {
    
                List<string> values = new List<string>();
    
                for (int i = 0; i < 12; i++)
                {
    
                    var rnd = new Random(DateTime.Now.Millisecond);
                    int ticks = rnd.Next(0, 2);
    
                    values.Add(ticks == 1 ? "R" : "B");
                    System.Threading.Thread.Sleep(2);
    
                }
    
                return values.ToArray();
    
            }
    
        }
    
    }
