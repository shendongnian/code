    static void Main(string[] args)
            {
                List<string> color1 = new List<string> { "blue", "green", "mother", "black", "gray" };
                List<string> color2 = new List<string> { "mother", "green", "father", "black", "gray" };
                string rd = GetRandom(color1);
                if (color2.Contains(rd))
                {
                    // do something
                    Console.WriteLine(rd);
                }
                else
                {
                    // do another work
                }           
                Console.Read();
            }
            static string GetRandom(List<string> color)
            {
                var arr = color.ToArray();
                Random rd=new Random();
                int n = rd.Next(arr.Length);
                return arr[n];
            }
