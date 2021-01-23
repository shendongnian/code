    public class NestedViewController : ViewController
    {
        protected PropertyCollectionSource PropertyCollectionSource
        {
            get
            {
                return View is ListView ? ((ListView)View).CollectionSource is PropertyCollectionSource ? ((ListView)View).CollectionSource as PropertyCollectionSource : null : null;
            }
        }
        protected object MasterObject
        {
            get
            {
                return PropertyCollectionSource != null ? PropertyCollectionSource.MasterObject : null;
            }
        }
    }
