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
                    foreach (List<int> Numbers in group)
                    {
                        if (Numbers.Contains(numberToAdd) && (group.IndexOf(Numbers) + 1) != groupToAddItTo)
                        {
                            active = group.IndexOf(Numbers) + 1;
                            IndexOfListToRefresh = group.IndexOf(Numbers);
                            foreach (int Number in Numbers)
                            {
                                NumbersToMove.Add(Number);
                            }
                        }
                    }
                    foreach (int Number in NumbersToMove)
                    {
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
                    foreach (List<int> Numbers in group)
                    {
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
