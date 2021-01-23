            List<List<int>> returnList = new List<List<int>>();
            foreach (var item in initList)
            {
                if (returnList.AsEnumerable().Where(p => !p.Except(item).Any() 
                                            && p.Count() == item.Count() ).Count() == 0)
                returnList.Add(item);
            }
