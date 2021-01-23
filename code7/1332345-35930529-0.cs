    string lastItem = history.Last();
       int lastIndexToCheck=history.Count-2,i=0;
       for (; i < potentialNew.Count - 1; i++)
           {
              if (potentialNew[i] == lastItem && potentialNew[i - 1] == history[lastIndexToCheck])
                  {
                     break;
                  }
           }
           history.AddRange(potentialNew.Skip(i+1).ToList());  
