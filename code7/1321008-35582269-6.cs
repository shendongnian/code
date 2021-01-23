    using System.Collections.Generic;
    
    namespace XXXNAMESPACEXXX
    {
        public static class Groups
        {
            public static List<List<int>> group { get; set; }
    
            public static void AddNumberToGroup(int numberToAdd, int groupToAddItTo)
            {
                try
                {
                    if (group == null)
                    {
                        group = new List<List<int>>();
    
                    }
    
                    while (group.Count < groupToAddItTo + 1)
                    {
                        group.Add(new List<int>());
    
                    }
    
                    List<int> ListToRefresh = null;
    
                    foreach (List<int> Numbers in group)
                    {
                        if (Numbers.Contains(numberToAdd))
                        {
                            foreach (int Number in Numbers)
                            {
                                group[groupToAddItTo].Add(Number);
    
                            }
    
                            ListToRefresh = Numbers;
    
                        }
    
                    }
    
                    if(ListToRefresh != null)
                    {
                        ListToRefresh = new List<int>();
    
                    }
                    else
                    {
                        group[groupToAddItTo].Add(numberToAdd);
    
                    }
    
                }
                catch//(Exception ex)
                {
                    //Exception handling here
                }
            }
    
        }
    
    }
