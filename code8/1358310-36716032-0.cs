    public class LineLayout : UICollectionViewFlowLayout
	{
        public float ITEM_SIZE;
		public const int ACTIVE_DISTANCE = 400;
		public const float ZOOM_FACTOR = 0.8f;
		public LineLayout ()
		{
            ITEM_SIZE = (float)CollectionView.Bounds.Size.Width / 2.0f;
			ItemSize = new CGSize (ITEM_SIZE, ITEM_SIZE);
			ScrollDirection = UICollectionViewScrollDirection.Vertical;
            SectionInset = new UIEdgeInsets (0,400,0,400);
			MinimumLineSpacing = 50.0f;
		}
        ...
