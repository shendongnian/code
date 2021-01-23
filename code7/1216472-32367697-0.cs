    class Program
        {
            static void Main(string[] args)
            {
                string s = "abc123djhfh123hfghh123jkj12";
                string v = "123";
                int index = 0;
                while (s.IndexOf(v, index) >= 0)
                {
                    int startIndex = s.IndexOf(v, index);
                    Console.WriteLine(startIndex);
                    //do something with startIndex
                    index = startIndex + v.Length ;
                }
                Console.ReadLine();
            }
        }
