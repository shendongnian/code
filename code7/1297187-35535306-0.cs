    	public sealed override void ViewDidLoad ()
		{
			if (!_isInitialised)
				return;
			
			base.ViewDidLoad ();
			CollectionView.RegisterNibForCell (MovieCollectionViewCell.Nib, MovieCollectionViewCell.Key);
			var source = new MoviesCollectionViewDataSource (ViewModel, CollectionView, MovieCollectionViewCell.Key);
			CollectionView.Source = source;
			this.CreateBinding(source).To<HomeViewModel>(vm => vm.MoviesSections).Apply();
			this.CreateBinding(source).For(s => s.SelectionChangedCommand).To<HomeViewModel>(vm => vm.ShowDetailViewCommand).Apply();
			CollectionView.ReloadData();
		}
