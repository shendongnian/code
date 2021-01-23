    // Flow Layout
    var flowLayout = new UICollectionViewFlowLayout (){
        ItemSize = new CGSize ((float)UIScreen.MainScreen.Bounds.Size.Width/2.0f, (float)UIScreen.MainScreen.Bounds.Size.Width/2.0f),
        HeaderReferenceSize = new CGSize (100, 100),
        SectionInset = new UIEdgeInsets (0,0,0,0),
        ScrollDirection = UICollectionViewScrollDirection.Vertical,
	    MinimumInteritemSpacing = 0, // minimum spacing between cells
		MinimumLineSpacing = 0 // minimum spacing between rows if ScrollDirection is Vertical or between columns if Horizontal
    };
    simpleCollectionViewController = new UICollectionViewController (flowLayout);
