    public static bool ContainsAny(IList<string> source)
    {
         int count = source.Count;
         for (int i = 0; i < count; i++)
         {
              for (int j = 0; j < count; j++)
              {
                  if (i != j && source[i].Contains(source[j]))
                  {
                      return true;
                  }
              }
          }
          return false;
    }
