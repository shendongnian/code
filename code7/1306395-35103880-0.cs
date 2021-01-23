    public class FeedDal{
        public FeedDal()
        {
          new Task(() =>
          { 
              for (int i = 0; i < 100; i++)
                   BuildFeed()
          }).Start();
        }
        private void BuildFeed()
        {
            // Will go here 100 times.
        }
    }
