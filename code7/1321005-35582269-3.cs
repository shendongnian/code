    public static List<List<int>> group { get; set; }
    public static void AddNumberToGroup(int numberToAdd, int groupToAddItTo)
    {
        try
        {
            if(group == null)
            {
                group = new List<List<int>>();
            }
            while(group.Count < groupToAddItTo + 1)
            {
                group.add(new List<int>();
            }
            foreach(List<int> Numbers in group)
            {
                if(Numbers.Contains(numberToAdd))
                {
                    Numbers.Remove(numberToAdd);
                }
            }
            group[groupToAddItTo].add(numberToAdd);
        }
        catch//(Exception ex)
        {
            //Exception handling here
        }
    }
