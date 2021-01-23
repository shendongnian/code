    //let's assume dict is a reference to the dictionary
    //k is a number, and g is a group
    void AddNumber(int k, int g)
    {
        //if k already has assigned a group, we assign all numbers from g
        //to k's group (which should be O(n))
        if(dict.ContainsKey(k))
        {
            foreach(var keyValuePair in dict.Where(kvp => kvp.Value == g))
                dict[keyValuePair.Key] = dict[k];
        }
        //otherwise simply assign number k to group g (which should be O(1))
        else
        {
            dict[k] = g;
        }
    }
