    // I'm assuming zipcodes are ints... convert if desired
    // jumbled up your sample data to show that the code would still work
    var zipcodes = new List<int>
    {
        90012,
        90033,
        90009,
        90001,
        90005,
        90004,
        90041,
        90008,
        90007,
        90031,
        90010,
        90002,
        90003,
        90034,
        90032,
        90006,
        90022,
    };
    // facilitate constant-time lookups of whether zipcodes are in your set
    var zipHashSet = new HashSet<int>();
    // lookup zipcode -> linked list node to remove item in constant time from the linked list
    var nodeDictionary = new Dictionary<int, DoublyLinkedListNode<int>>();
    // linked list for iterating and grouping your zip codes in linear time
    var zipLinkedList = new DoublyLinkedList<int>();
    // initialize our datastructures from the initial list
    foreach (int zipcode in zipcodes)
    {
        zipLinkedList.Add(zipcode);
        zipHashSet.Add(zipcode);
        nodeDictionary[zipcode] = zipLinkedList.Last;
    }
    // object to store the groupings (ex: "90001-90010", "90022")
    var groupings = new HashSet<string>();
    // iterate through the linked list, but skip nodes if we group it with a zip code
    // that we found on a previous iteration of the loop
    var node = zipLinkedList.First;
    while (node != null)
    {
        var bottomZipCode = node.Element;
        var topZipCode = bottomZipCode;
        // find the lowest zip code in this group
        while (zipHashSet.Contains(bottomZipCode - 1))
        {
            var nodeToDel = nodeDictionary[bottomZipCode - 1];
            // delete node from linked list so we don't observe any node more than once
            if (nodeToDel.Previous != null)
            {
                nodeToDel.Previous.Next = nodeToDel.Next;
            }
            if (nodeToDel.Next != null)
            {
                nodeToDel.Next.Previous = nodeToDel.Previous;
            }
            // see if previous zip code is in our group, too
            bottomZipCode--;
        }
        // get string version zip code bottom of the range
        var bottom = bottomZipCode.ToString();
        // find the highest zip code in this group
        while (zipHashSet.Contains(topZipCode + 1))
        {
            var nodeToDel = nodeDictionary[topZipCode + 1];
            // delete node from linked list so we don't observe any node more than once
            if (nodeToDel.Previous != null)
            {
                nodeToDel.Previous.Next = nodeToDel.Next;
            }
            if (nodeToDel.Next != null)
            {
                nodeToDel.Next.Previous = nodeToDel.Previous;
            }
            // see if next zip code is in our group, too
            topZipCode++;
        }
        // get string version zip code top of the range
        var top = topZipCode.ToString();
        // add grouping in correct format
        if (top == bottom)
        {
            groupings.Add(bottom);
        }
        else
        {
            groupings.Add(bottom + "-" + top);
        }
        // onward!
        node = node.Next;
    }
    // print results
    foreach (var grouping in groupings)
    {
        Console.WriteLine(grouping);
    }
