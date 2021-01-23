        private ObservableCollection<Movie> Movies = new ObservableCollection<Movie>();
        private async void AboutPage_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var movie in await GetMovies())
            {
                Movie.Add(movie);
            }
        }
