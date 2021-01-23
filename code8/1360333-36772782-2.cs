    public void ThreadTest()
    {
      try
      {
        var options = new ParallelOptions { MaxDegreeOfParallelism = 2 };
        Parallel.For(1, 5, options, i => Faulty());
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.ToString());
      }
    }
    private void Faulty()
    {
      throw new Exception("Never reach the work");
      Thread.Sleep(3000); // Naturally synchronous operation
    }
