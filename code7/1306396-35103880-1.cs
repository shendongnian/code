    public class FeedDal
    {
        public FeedDal()
        {
          while (true)
          {
              new Task(() => BuildFeed()).Start();
              Thread.Sleep(1000);
          }
        }
        private void BuildFeed()
        {
            // Will go here once a second.
        }
    }
