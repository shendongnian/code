       for (int i = 0; i < list1.Count; i++)
            {
                var kar = list1.ElementAt(i);
                for (int j = i+1; j < list1.Count; j++)
                {
                    if (Enumerable.SequenceEqual(kar.requestorList.OrderBy(t => t), list1.ElementAt(j).requestorList.OrderBy(t => t)))
                    {
                        list2.Add(kar);
                        list2.Add(list1.ElementAt(j));
                    }
                }
            }
