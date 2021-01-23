    public void PrintGoldmineCombinations(int count, List<GoldMine> mines)
    {
        Debug.WriteLine("count = " + count);
        var groupNumber = 0;
        foreach (var group in mines.GroupCombinations(count))
        {
            groupNumber++;
            Debug.WriteLine("group " + groupNumber);
            foreach (var set in group)
            {
                Debug.WriteLine(set.Key + ": " + set.Sum(m => m.TonsOfGold) + " tons of gold");
            }
        }
    }
