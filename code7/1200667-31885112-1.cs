    public static void test()
        {
            string test1 = "word1,word2,word3,word4";
            string test2 = "word2,word4";
            List<string> test1list = test1.Split(',').ToList();
            List<string> test2Lists = test2.Split(',').ToList();
            List<string> result = new List<string>();
            foreach (var item in test1list)
            {
                if (!test2Lists.Contains(item))
                {
                    if (result.Any())
                    {
                        result.Add(","  +item );
                    }
                    else
                    {
                        result.Add(item);
                    }
                    
                }
            }
            result.ForEach(p => Console.Write(p));
            Console.ReadLine();
        }
