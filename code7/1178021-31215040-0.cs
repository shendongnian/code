    private static void Main(string[] args)
    {
        // This is the master list of IDs - no repeats. Hard coded here for the example.
        var masterDictionary = new Dictionary<string, int>();
        var masterArray = new string[15] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "K", "L", "M", "N", "O", "P" };
        for (var i = 0; i < masterArray.Length; i++)
        {
            masterDictionary.Add(masterArray[i], i);
        }
        var uniqueArrays = GetUniqueArrays(masterDictionary);
        Console.WriteLine("Unique array collection has {0} arrays. Press any key to continue.", 
            uniqueArrays.Count);
        Console.ReadLine();
    }
    /// <summary>
    /// Create a collection of arrays which are not subsets of a larger array where order matters,
    /// i.e. { "A", "B", "C" } != { "C", "B", "A" } and the array values are in contiguous 
    /// indexes in both the superset and subset arrays.
    /// </summary>
    /// <returns></returns>
    private static List<string[]> GetUniqueArrays(Dictionary<string, int> masterDictionary)
    {
        // This is the list of subsets I'll return
        var uniqueArrays = new List<string[]>();
        // This the superset of IDs, no repeats. We'll use an ordered dictionary because
        // we need to find values in it by index.
        var supersetDictionary = new OrderedDictionary();
        var supersetArray = new string[7] { "A", "B", "C", "D", "E", "F", "G" };
        for (var i = 0; i < supersetArray.Length; i++)
        {
            var value = 0;
            masterDictionary.TryGetValue(supersetArray[i], out value);
            supersetDictionary.Add(supersetArray[i], value);
        }
        // The superset array will always be in the list we return.
        uniqueArrays.Add(supersetArray);
        // Hard code some subsets and add them to a collection
        var subsets = new List<string[]>();
        // Is a subset
        var subsetOne = new string[6] { "A", "B", "C", "D", "E", "F" };
        subsets.Add(subsetOne);
        // Is a subset
        var subsetTwo = new string[6] { "B", "C", "D", "E", "F", "G" };
        subsets.Add(subsetTwo);
        // Is a subset
        var subsetThree = new string[3] { "B", "C", "D" };
        subsets.Add(subsetThree);
        // Is NOT a subset
        var subsetFour = new string[3] { "D", "C", "B" };
        subsets.Add(subsetFour);
        // Check if the subsetArray is a subset of the supersetArray. If it is not
        // then add it to the list of unique subsets
        foreach (var subset in subsets)
        {
            if (!CheckIsSubset(masterDictionary, supersetDictionary, subset)) 
                uniqueArrays.Add(subset);
        }
        return uniqueArrays;
    }
    /// <summary>
    /// Determine an array is a subset of a larger array where order matters,
    /// i.e. { "A", "B", "C" } != { "C", "B", "A" } and the array values are in 
    /// contiguous indexes in both the superset and subset arrays.
    /// </summary>
    /// <param name="masterSet"></param>
    /// <param name="superset"></param>
    /// <param name="subset"></param>
    /// <returns></returns>
    private static bool CheckIsSubset(Dictionary<string, int> masterSet, 
        OrderedDictionary superset, string[] subset)
    {
        var supersetIndex = -1;
        for (var i = 0; i < subset.Length - 1; i++)
        {
            // Get the masterDictionary value for the first ID in the subsetArray
            var idValue = -1;
            masterSet.TryGetValue(subset[i], out idValue);
            if (idValue >= 0)
            {
                // Next determine if the first ID in the subset array is in the superset.
                if (supersetIndex == -1)
                {
                    for (var j = 0; j < superset.Count; j++)
                    {
                        // Get the ID at index j from the superset and compare it to subset ID
                        var supersetId = superset.Cast<DictionaryEntry>().ElementAt(j).Key.ToString();
                        var subsetId = subset[i];
                        if (subsetId == supersetId)
                        {
                            // This is the index in the superset from where we want to start our comparison
                            supersetIndex = j;
                            break;
                        }
                    }
                    // The first ID is not in the superset so we know the array we're testing is not
                    // a subset.
                    if (supersetIndex == -1)
                    {
                        return false;
                    }
                }
            }
            else
            {
                var error = string.Format("The ID {0} is not in the master list.", idValue);
                throw new Exception(error);
            }
            // We have a match. Next we want to step through the subset array.
            // We next test for matches in the adjoining indexes
            supersetIndex++;
            if (superset.Count >= supersetIndex)
            {
                // Get the superset value at this index and compare it to the subset value
                var supersetKey = superset.Cast<DictionaryEntry>().ElementAt(supersetIndex).Key.ToString();
                var subsetValue = subset[i + 1];
                if (subsetValue != supersetKey) return false;
            }
            else
            {
                // The supersetIndex is at or greater than the length of the superset array
                // so our subset is unique.
                return false;                    
            }
        }
        // The array we're examining is a subset of the larger array
        return true;
    }
