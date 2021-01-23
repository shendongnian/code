	public partial class NestedViewController : ViewController
	{
		protected PropertyCollectionSource PropertyCollectionSource => (View as ListView)?.CollectionSource as PropertyCollectionSource;
		protected object MasterObject => PropertyCollectionSource?.MasterObject;
	}
