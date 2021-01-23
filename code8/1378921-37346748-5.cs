	namespace Yalla.Launcher.ViewModels
	{
		using System.ComponentModel;
		using Commands;
		using Features.Commands.Search;
		public class SearchViewModel : INotifyPropertyChanged, ISearchableText
		{
			private SearchCommandHandler _enterCommandHandler;
			private string _searchText;
			public event PropertyChangedEventHandler PropertyChanged;
			public SearchCommandHandler Search => _enterCommandHandler ?? (_enterCommandHandler = new SearchCommandHandler(new SearchService(this)));
			public string SearchText
			{
				get
				{
					return _searchText;
				}
				set
				{
					_searchText = value;
					OnPropertyChanged(nameof(SearchText));
				}
			}
			protected virtual void OnPropertyChanged(string propertyName = null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
