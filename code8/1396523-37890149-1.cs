        using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    
    namespace ChkList_Learning
    {
        /// <summary>
        /// Interaction logic for Window2.xaml
        /// </summary>
        public partial class Window2 : Window
        {
            public Window2()
            {
                InitializeComponent();
                this.DataContext = new SongViewModel();
            }
        }
    
        class SongViewModel
        {
            public ObservableCollection<Song> SongList { get; set; }
    
            public SongViewModel()
            {
                SongList = new ObservableCollection<Song>();
                for (int i = 0; i < 10; i++)
                {
                    Song song = new Song();
                    song.Title = (i + 1).ToString();
                    song.SongName = "Song Name" + (i + 1).ToString();
                    song.AlbumName = "My Album";
                    SongList.Add(song);
                }
            }
        }
    
        class Song
        {
            public string Title { get; set; }
            public string SongName { get; set; }
    
            public string AlbumName { get; set; }
        }
    }
