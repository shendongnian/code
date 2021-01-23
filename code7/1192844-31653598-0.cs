     int count = Math.Max(firstArray.Count(), secondArray.Count());
    
     for (int i = 0; i < count; i++)
     {
          var value1 = firstArray.ElementAtOrDefault(i) ?? String.Empty;
          var value2 = secondArray.ElementAtOrDefault(i) ?? String.Empty;
    
          var newLine = string.Format("{0},{1}", value1, value2);
          sw.Write(newLine);
     }
