    private ObservableCollection<MusicLib> MusicList = new ObservableCollection<MusicLib>();
    
    public MainPage()
    {
        this.InitializeComponent();
    }
    
    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        StorageFolder musicLib = KnownFolders.MusicLibrary;
        var files = await musicLib.GetFilesAsync();
        foreach (var file in files)
        {
            var musicProperties = await file.Properties.GetMusicPropertiesAsync();
            var artist = musicProperties.Artist;
            if (artist == "")
                artist = "Artista desconocido";
            var album = musicProperties.Album;
            if (album == "")
                album = "Unkown";
            MusicList.Add(new MusicLib { FileName = file.DisplayName, Artist = artist, Album = album });
        }
    }
