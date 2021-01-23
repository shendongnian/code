	public class Movie
	{
		public string Actor { get; set; }
		public string Name { get; set; }
	}
	public class MovieList : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			var mevent = PropertyChanged;
			if (mevent != null)
			{
				mevent(this, e);
			}
		}
		ObservableCollection<Movie> Movieitems = new ObservableCollection<Movie>();
		public ObservableCollection<Movie> MovieItems
		{
			get { return Movieitems; }
			set
			{
				if (Movieitems == value)
				{
					return;
				}
				Movieitems = value;
				OnPropertyChanged(new PropertyChangedEventArgs("MovieItems"));
			}
		}
		public MovieList()
		{
			Movieitems.Add(new Movie { Name = "Kaavalan", Actor = "Vijay", });
			Movieitems.Add(new Movie { Name = "Velayutham", Actor = "Vijay", });
			Movieitems.Add(new Movie { Name = "7th Sense", Actor = "Surya", });
			Movieitems.Add(new Movie { Name = "Billa 2", Actor = "Ajith Kumar", });
			Movieitems.Add(new Movie { Name = "Nanban", Actor = "Vijay", });
		}
	}
