        public sealed partial class MainPage : Page, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private List<Movie> _movies;
            public List<Movie> Movies
            {
                get { return _movies; }
                set { if(value != _movies) { _movies = value; PropertyChanged?.Invoke(nameof(Movies)); } }
            }
            public MainPage()
            {
                this.InitializeComponent();
            }
            private async void Page_Loaded(object sender, RoutedEventArgs e)
            {
                Movies = await MovieManager.GetMovies();
            }
        }
    Xaml:
        <GridView Grid.Row="0" ItemsSource="{x:Bind Movies, Mode=OneWay}" ItemTemplate="{StaticResource MovieDataTemplate}" />
