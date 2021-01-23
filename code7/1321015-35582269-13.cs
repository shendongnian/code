    using System;
    using System.Collections.Generic;
    
    namespace XXXNAMESPACEXXX
    {
        public static class Groups
        {
            public static List<List<int>> group { get; set; }
            public static int active { get; set; }
    
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
    
                    List<int> NumbersToMove = new List<int>();
    
                    foreach (List<int> Numbers in group)
                    {
                        if (Numbers.Contains(numberToAdd))
                        {
                            active = group.IndexOf(Numbers);
                            foreach (int Number in Numbers)
                            {
                                NumbersToMove.Add(Number);
    
                            }
    
                            ListToRefresh = Numbers;
    
                        }
    
                    }
    
                    foreach(int Number in NumbersToMove)
                    {
                        if (!group[groupToAddItTo].Contains(Number))
                        {
                            group[groupToAddItTo].Add(Number);
    
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
    
            public static string GetString()
            {
                string MethodResult = "";
                try
                {
                    string Working = "";
    
                    bool FirstPass = true;
    
                    foreach(List<int> Numbers in group)
                    {
                        if (!FirstPass)
                        {
                            Working += "\n";
    
                        }
                        else
                        { 
                            FirstPass = false;
    
                        }
    
                        Working += "group[" + group.IndexOf(Numbers) + "]{";
    
                        bool InnerFirstPass = true;
    
                        foreach (int Number in Numbers)
                        {
                            if (!InnerFirstPass)
                            {
                                Working += ", ";
    
                            }
                            else
                            {
                                InnerFirstPass = false;
    
                            }
    
                            Working += Number.ToString();
    
                        }
                        
                        Working += "};";
                        if(active == group.IndexOf(Numbers))
                        {
                            Working += " //<active>"
                        }
                    }
    
                    MethodResult = Working;
    
                }
                catch//(Exception ex)
                {
                    //Exception handling here
                }
                return MethodResult;
            }
    
        }
    
    }
