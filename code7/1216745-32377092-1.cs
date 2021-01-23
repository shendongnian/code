    for (int i = 0; i < list1.Count; i++)
            {
                var kar = list1.ElementAt(i);
                for (int j = 0; j < list1.Count; j++)
                {
                if(kar.requestorList.Equals(list1.ElementAt(j).requestorList))
                    {
                         if(list1.ElementAt(i).Equals(list1.ElementAt(j))){
                              continue;
                         }
                         if(!list2.Contains(kar)){
                             list2.Add(kar);
                         }
                    }
                }
            }
