        static void TryCatchFunction()
        {
            ConcurrentBag<string> bag = null;
            int numItemsInBag = 0;
            try
            {
                ErrorFunction(out bag);
                numItemsInBag = bag.Count;
            }
            catch (Exception)
            {
                numItemsInBag = bag.Count;
            }
        }
        static void ErrorFunction(out ConcurrentBag<string> bag)
        {
            string[] strings = new string[] { "1", "2", "3", "4", "5", "6" };
            ConcurrentBag<string> inFunctionBag = new ConcurrentBag<string>();
            bag = inFunctionBag;
            
            Parallel.ForEach(strings, (str, state) =>
            {
                if (str == "2" || str == "4")
                {
                    inFunctionBag.Add(str);
                    throw new Exception();
                }
            });
        }
