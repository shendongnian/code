            //  Use your Uow.Gems.GetAll() list of gems 
            string[] gems = new string[] { "F12", "T16", "K15", "F10", "K14", "T9", "T7", "A12", "A11" };
            string input = "A12";
            //Cache it something like this Uow.Gems.GetAll().OrderBy(x => x, new GemComparer()).ToList()
            var cacheGems = gems.OrderBy(x => x, new GemComparer());
            foreach (var thing in cacheGems)
            {
                Console.WriteLine(thing);
            }
            var previous = cacheGems.TakeWhile(x => x != input).LastOrDefault();
            var next = cacheGems.SkipWhile(x => x != input).Skip(1).FirstOrDefault();
            Console.WriteLine(previous);
            Console.WriteLine(next);
