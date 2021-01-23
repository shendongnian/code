    //this is the datastructure to hold the results
    static List<KeyValuePair<string, List<int>>> Set = new List<KeyValuePair<string, List<int>>>();
    private static void GetData(List<int> lst, int group)
    {
        int count = 1;
                
        int pivot = lst.First();
                
        if (lst.Count < group)
        {
            return;
        }
        else
        {
            foreach (int i in lst.Skip(1))
            {
                if (i == pivot)
                {
                    count++;
                }
                else if (count == group)
                {
                    Set.Add(new KeyValuePair<string, List<int>>("Set of items " + pivot, lst.Take(count).ToList()));
                    GetData(lst.Skip(count).ToList(), group);
                    break;
                }
                else
                {
                    GetData(lst.Skip(count).ToList(), group);
                    break;
                }
            }
        }
    }
