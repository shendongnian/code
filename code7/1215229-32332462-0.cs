    public class SomeDataSource : UICollectionViewDataSource
    {
        private WeakReference<object> weakController;
        public SomeDataSource (object controller)
        {
            this.weakController = new WeakReference<object>(controller);
        }
    }
