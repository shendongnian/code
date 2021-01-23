            var list1 = new List<string>();
            var list2 = new List<string>();
            var list3 = new List<string>();
            var allLists = new List<string>[] { list1, list2, list3 };
            // need to be sure you have >= 1 list(s)
            var result = allLists[0];
            for (int i = 1; i < allLists.Length; i++)
            {
                result = result.Intersect(allLists[i]).ToList();
            }
            // ok, you get the result
