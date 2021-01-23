    foreach (KeyValuePair<string, int> kvp in integers)
        {
           if (name1 == kvp.Key)
           {
               value1 = kvp.Value;
           }
    
           if (name2 == kvp.Key)
           {
               value2 = kvp.Value;
           }
    
           int answer = value1 + value2;
    
           
        }
        Console.WriteLine(answer);
