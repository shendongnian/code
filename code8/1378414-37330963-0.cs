    Dictionary<int, int> dict = new Dictionary<int, int>();
    ...
        if (array[i] == array[j])
        {
            if (dict.ContainsKey(array[i]))
            {
                dict[array[i]] += 1; 
            }
            else
            {
                dict.Add(array[i], 1);
            }                        
        }
    
    ...
    foreach (int key in dict.Keys)
    {
        Console.WriteLine(key + " repeats " + dict[key] + " times");
    }
