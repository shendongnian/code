    static void Insert<Type>(IList<Type> outputCollection, IList<Type> inputCollection,  int start, int end)
    {
          if (end >= inputCollection.Count)
             return;
          for (int i = start; i < end; i++)
              outputCollection.Add(inputCollection[i]);
    }
