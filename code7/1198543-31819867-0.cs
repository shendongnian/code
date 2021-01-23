    public static void CompareAll(List<Action> compareDelegates)
    {
        List<Exception> exceptions = new List<Exception>();
      // The issue is in below line - how to pass parameters to the delegate
        compareDelegates.ForEach(del =>
        {
            try
            {
                del.Invoke();
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }
        });
    }
    // somewhere else...
    List<Action> compareDelegates = new List<Action>();
    compareDelegates.Add(() => Compare(1,2));
    CompareAll(compareDelegates);
