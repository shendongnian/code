    namespace TestApp1
    {
        class Program
        {
    
            static void Main(string[] args)
            {
    
                string[] test = GetValues();
                string testView = String.Join(String.Empty, test);
                string score = GetScore(test).ToString();
                Console.WriteLine(testView);
                Console.WriteLine(score);
                Console.ReadLine();
            }
    
            public static int GetScore(string[] test)
            {
    
                int score = 0;
                int occurence = 0;
                string LastChar = string.Empty;
    
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
                                score += occurence * 2;
                            }
                        }
    
                    }
                    else
                    {
    
                        if(occurence > 1)
                        {
                            score += occurence * 2;
                        }
    
                        LastChar = test[i];
                        occurence = 1;
                   
                    }
                     
                }
    
                return score;
    
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
