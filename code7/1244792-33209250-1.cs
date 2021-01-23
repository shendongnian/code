	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	// MVVM Violation, it's part of WPF 
	using System.Windows.Data;
	// MVVM Violation, it's part of WPF (usually PresentationFramework.dll)
	using System.Windows.Media;
	using Client.Model;
	namespace Client.ViewModel
	{
		public class PagerViewModel : ViewModelBase
		{
			...
			// MVVM Violation, it's a type from Assembly:  PresentationFramework (in PresentationFramework.dll)
			ListCollectionView _listCollectionView;
			ObservableCollection<IPagableEntry> _collection;
			int _rows;
			int _columns;
			public int Rows
			{
				get { return _rows; }
				set
				{
					_rows = value;
					OnPropertyChanged();
				}
			}
			public int Columns
			{
				get { return _columns; }
				set
				{
					_columns = value;
					OnPropertyChanged();
				}
			}
			public ListCollectionView ListCollectionView
			{
				get { return _listCollectionView; }
				set
				{
					_listCollectionView = value;
					OnPropertyChanged();
				}
			}
			public ObservableCollection<IPagableEntry> Collection
			{
				get
				{
					return _collection;
				}
				set
				{
					_collection = value;
					OnPropertyChanged();
				}
			}
			...
		}
	}
