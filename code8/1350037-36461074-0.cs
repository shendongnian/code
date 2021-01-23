    public T Retry<T>(Func<T> getter, int count)
    {
      for (int i = 0; i < (count - 1); i++)
      {
        try
        {
          return getter();
        }
        catch (Exception e)
        {
          // Log e
        }
      }
      return getter();
    }
    const int retryCount = 3;
    Customer customer = Retry(() => GetCustomerByID(id), retryCount);
    string customerFullName = Retry(() => GetCustomerFullNamebyId(id), retryCount);
