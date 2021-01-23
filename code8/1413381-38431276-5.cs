    public static bool SelfDescribing(string num)
    {
        bool result = true;
    
        int[] numbersArray = num.ToArray().Select(x => (int)char.GetNumericValue(x)).ToArray();
    
        var occurences = numbersArray.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    
        for (int i = 0; i < numbersArray.Length; i++)
        {
            int occ;
    
            if (occurences.TryGetValue(i, out occ))
            {
                if(occ != numbersArray[i])
                {
                    result = false;
                    break;
                }
            }
            else
            {
                if (i == 0)
                    continue;
            }
        }
    
        return result;
    }
