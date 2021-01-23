    var dictionary = new Dictionary<string, int> {{"AAA", 1},{"BBB", 0}, {"CCC", 1}};
    int maxValue = dictionary.Values.Max();
    string keyMax = null; 
    if (dictionary.Values.Count(v => v == maxValue) == 1)
    {
        keyMax = dictionary.First(v => v.Value == maxValue).Key;
    }
    else
    {
        // Multiple items with value equals to max
    }
