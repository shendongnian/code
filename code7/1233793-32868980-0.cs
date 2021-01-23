        public partial class ListView : UserControl
	    {
		public ListView()
		{
			this.InitializeComponent();
		}
		
		bool _showFavorite;
		public bool ShowFavorite{
			get{return _showFavorite;}
			set{_showFavorite = value;
			
				if(value == true)
				{
					CollectionView v = (CollectionView)CollectionViewSource.GetDefaultView(MyItemsControl.ItemsSource);
					v.Filter = (i)=>{return ((ListStruct)i).IsFavorite==true;};
					v.Refresh();
				}
				else	
				{
					CollectionView v = (CollectionView)CollectionViewSource.GetDefaultView(MyItemsControl.ItemsSource);
					v.Filter = (i)=>{return ((ListStruct)i).IsFavorite==false;};
					v.Refresh();
				}
			}
		}
	}
