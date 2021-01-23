    // using a list inside for now for easier adding
    var backTranspose = new List<List<string>>();
    
    // determine the max number of measurements for a channel name
    var maxLength = transposedData.Values.Max(l => l.Count);
    
    // use one more to include key
    for (var valueIndex = 0; valueIndex <= maxLength; valueIndex++)
    {
      backTranspose.Add(new List<string>());
    }
    
    foreach (var kvp in transposedData)
    {
      var index = 0;
      backTranspose[index].Add(kvp.Key);
    
      for (var valueIndex = 0; valueIndex < maxLength; valueIndex++)
      {
        index++;
        if (kvp.Value.Count > valueIndex)
        {
          backTranspose[index].Add(kvp.Value[valueIndex]);
        }
        else
        {
          backTranspose[index].Add(null);
        }
      }
    }
    
    // turn the lists back into arrays
    parsedData = new List<string[]>();
    foreach (var list in backTranspose)
    {
      parsedData.Add(list.ToArray());
    }
