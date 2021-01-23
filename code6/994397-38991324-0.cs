    public class PreWarmUp : IProcessHostPreloadClient
    {
      public void Preload(string[] parameters)
      {
        QuartzHelper.RunJob();
      }
    }
