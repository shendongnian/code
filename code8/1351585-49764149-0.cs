    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
    {
        var dictionary = new Dictionary<int, int>();
        
        for (var i = 0; i < list.Count; i++)
        {
            var aim = sum - list[i];
            
            if(dictionary.ContainsKey(aim))
            {
                return new Tuple<int, int> (dictionary[aim], i);
            }
            else if(!dictionary.ContainsKey(list[i]))
            {
                dictionary.Add(list[i], i);
            }
        }
        return null;
    }
