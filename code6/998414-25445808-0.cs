    private bool aborted = false;
    public ResultClass Method()
    {
        for (i = 0; i < int.MaxValue && !aborted; i++)
        {
          // ...
        }
        if (aborted)
        {
            return null;
        }
        return new ResultClass(...);
    }
    public void Abort()
    {
        aborted = true;
    }
