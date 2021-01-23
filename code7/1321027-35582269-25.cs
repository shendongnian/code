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
                    while (group.Count < groupToAddItTo)
                    {
                        group.Add(new List<int>());
                    }
                    int IndexOfListToRefresh = -1;
                    List<int> NumbersToMove = new List<int>();
                    for(int i = 0; i < group.Count; i++)
                    {
                        List<int> Numbers = group[i];
                        int IndexOfNumbers = group.IndexOf(Numbers) + 1;
                        if (Numbers.Contains(numberToAdd) && IndexOfNumbers != groupToAddItTo)
                        {
                            active = IndexOfNumbers;
                            IndexOfListToRefresh = IndexOfNumbers - 1;
                        
                            for (int j = 0; j < Numbers.Count; j++)
                            {
                                int Number = NumbersToMove[j];
                            
                                NumbersToMove.Add(Number);
                            }
                        }
                    }
                    for(int i = 0; i < NumbersToMove.Count; i++)
                    {
                        int Number = NumbersToMove[i];
                        if (!group[groupToAddItTo - 1].Contains(Number))
                        {
                            group[groupToAddItTo - 1].Add(Number);
                        }
                    }
                    if (!group[groupToAddItTo - 1].Contains(numberToAdd))
                    {
                        group[groupToAddItTo - 1].Add(numberToAdd);
                    }
                    if (IndexOfListToRefresh != -1)
                    {
                        group[IndexOfListToRefresh] = new List<int>();
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
                    for(int i = 0; i < group.Count; i++)
                    {
                        List<int> Numbers = group[i];
                        if (!FirstPass)
                        {
                            Working += "\r\n";
                        }
                        else
                        {
                            FirstPass = false;
                        }
                        Working += "group[" + (group.IndexOf(Numbers) + 1) + "]{";
                        bool InnerFirstPass = true;
                        for(int j = 0; j < Numbers.Count; j++)
                        {
                            int Number = Numbers[j];
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
                        if ((active - 1) == group.IndexOf(Numbers))
                        {
                            Working += " //<active>";
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
