           // Use your Uow.Gems.GetAll() list of gems 
            string[] gems = new string[] { "F12", "T16", "K15", "F10", "K14", "T9", "T7", "A12", "A11" };
            //Cache it something like this Uow.Gems.GetAll().OrderBy(x => x, new GemComparer()).ToList()
            List<string> cacheGems = gems.OrderBy(x => x, new GemComparer()).ToList();
            foreach (var gemin cacheGems)
            {
                Console.WriteLine(gem);
            }
            string input = "T9";
            var index = cacheGems.FindIndex(o => o == input);
            Console.WriteLine(cacheGems[index - 1]);
