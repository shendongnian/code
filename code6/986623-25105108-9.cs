    public class ViewModel
    {
        public ObservableCollection<Music> Musics { get; set; }
        public ViewModel()
        {
            FillMusic();
        }
        void FillMusic()
        {
            Musics = new ObservableCollection<Music> 
            { new Music { Genre = "POP Music", PlayList = new ObservableCollection<string> { "sample1", "sample2", } },
            new Music { Genre = "Club Music", PlayList = new ObservableCollection<string> { "sample1", "sample2", "sample3"} },
            new Music { Genre = "Retro", PlayList = new ObservableCollection<string> { "sample1" } }};
        }
    }
