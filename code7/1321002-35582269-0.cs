    public static void RemoveExistingNumberFromGroup(int numberToRemove)
    {
        try
        {
            foreach(List<int> Numbers in group)
            {
                if(Numbers.Contains(numberToRemove))
                {
                    group.Remove(numberToRemove);
                }
            }
        }
        catch//(Exception ex)
        {
            //Exception handling here
        }
    }
