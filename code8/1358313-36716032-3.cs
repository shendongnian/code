    // Flow Layout
            flowLayout = new UICollectionViewFlowLayout (){
                ItemSize = new CGSize ((float)UIScreen.MainScreen.Bounds.Size.Width/2.0f, (float)UIScreen.MainScreen.Bounds.Size.Width/2.0f),
                HeaderReferenceSize = new CGSize (100, 100),
                SectionInset = new UIEdgeInsets (20,20,20,20),
                ScrollDirection = UICollectionViewScrollDirection.Vertical,
				MinimumInteritemSpacing = 50, // minimum spacing between cells
				MinimumLineSpacing = 50 // minimum spacing between rows if ScrollDirection is Vertical or between columns if Horizontal
            };
