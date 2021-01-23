      // Output goes here
      List<int> output = new List<int>();
    
      // Make sure lists are sorted
      for (int i = 0; i < lists.Count; ++i) lists[i].Sort();
    
      // Maintain array of indices so we can step through all the lists in parallel
      int[] index = new int[lists.Count];
            
      for (index[0] = 0; index[0] < lists[0].Count; ++index[0])
      {
        // Search for each value in the first list
        int value = lists[0][index[0]];
        
        // No. lists that value appears in, we want this to equal lists.Count
        int count = 1;
    
        // Search all the other lists for the value
        for (int i = 1; i < lists.Count; ++i)
        {
          while (index[i] < lists[i].Count)
          {
            // Stop if we've passed the spot where value would have been
            if (lists[i][index[i]] > value) break;
    
            // Stop if we find value
            if (lists[i][index[i]] == value)
            {
              ++count; 
              break; 
            }
    
            ++index[i];
          }
    
          // If we reach the end of any list there can't be any more matches so end the search now
          if (index[i] >= lists[i].Count) goto done;
        }
    
        // Store the value if we found it in all the lists
        if (count == lists.Count) output.Add(value);
        // Skip multiple occurrances of the same value
        while (index[0] < lists[0].Count && lists[0][index[0]] == value) ++index[0];
      }
    
      done:
