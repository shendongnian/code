    bool AddItem<T>(BlockingCollection<T> blockingCollection, T item) {
      try {
        blockingCollection.Add(item);
        return true;
      }
      catch (InvalidOperationException) {
        return false;
      }
    }
