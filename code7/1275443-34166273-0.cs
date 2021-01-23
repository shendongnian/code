      public int Test(string value)
        {
            List<List<string>> nestedList = new List<List<string>>();
            nestedList.Add(new List<string> { "test1" });
            nestedList.Add(new List<string> { "test2" });
            nestedList.Add(new List<string> { "test3" });
            for (int i = 0; i < nestedList.Count; i++)
            {
                if (nestedList[i].Any(m => m == value))
                    return i;
            }
            //not found
            return -1;
        }
        //To use:
        public void Program() 
        {
            Console.WriteLine("found in index: {0}", Test("test3")); //found in index: 2 
            Console.WriteLine("found in index: {0}", Test("test4")); //found in index: -1
        }
