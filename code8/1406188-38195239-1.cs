      List<string> target = new List<string> { "1", "2", "3", "a", "b", "a", "b", "c", "1", "2", "a", "b", "c", "1" };
      List<string> match = new List<string> { "a", "b", "c" };
      Stack<int> matchIndexes = new Stack<int>();
      for (int x = 0; x < target.Count - match.Count; x++)
      {
          int matches = 0;
          for (int y = 0; y < match.Count; y++)
          {
              if (target[x + y] != match[y])
              {
                  break;
              }
              else
              {
                  matches++;
              }
          }
          if (matches == match.Count)
          {
              matchIndexes.Push(x);
          }
      }
      while(matchIndexes.Count > 0)
      {
          int index = matchIndexes.Pop();
          target.RemoveRange(index, match.Count);
      }
