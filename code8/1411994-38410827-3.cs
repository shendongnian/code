    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    
    namespace WpfApplicationTest
    {
        /// <summary>
        /// Interaction logic for WinNewGrid.xaml
        /// </summary>
        public partial class WinNewGrid : Window
        {
            public WinNewGrid()
            {
                InitializeComponent();
    
                List<MovieImage> images = new List<MovieImage>();
                foreach (string fileName in System.IO.Directory.GetFiles(@"C:\Users\Public\Pictures\Sample Pictures"))
                {
                    if (fileName.EndsWith("jpg") || fileName.EndsWith("png") || fileName.EndsWith("gif"))
                        images.Add(new MovieImage() { SourcePath = new Uri(fileName, UriKind.Absolute), ID = Guid.NewGuid().ToString() });
                }
    
                MovieAndDetailsViewModel movieDetailsVm = new MovieAndDetailsViewModel(images);
                movieDetailsVm.Columns = 3;
    
                this.DataContext = this;
                Dgrd.ItemsSource = movieDetailsVm.ItemsSource;
            }
        }
    
        public class MovieAndDetailsViewModel
        {
            private MovieSetsViewModel _setViewModel;
            private List<MovieSetsViewModel> _list;
            public IEnumerable<MovieSetsViewModel> ItemsSource 
            { 
                get {
                    _setViewModel = new MovieSetsViewModel();
                    int pointer = 0;
                    int cols = 6;
                    List<MovieListViewModel>[] images = Data.Count() % cols > 0 ? new List<MovieListViewModel>[Data.Count() / cols + 1]
                        : new List<MovieListViewModel>[Data.Count() / cols];
                    
                    while (pointer < images.Count())
                    {
                        MovieListViewModel mlistVm = new MovieListViewModel();
                        for (int i = pointer * cols; i < Data.Count() && i <= pointer * cols + cols - 1; ++i)
                        {
                            MovieImage img = Data.ToList()[i];
                            mlistVm.MovieImageList.Add(img);
                        }
                        _setViewModel.Sets.Add(mlistVm);
                        pointer += 1;
                    }
    
                    _list = new[] { _setViewModel }.ToList();
                    return _list; 
                }
            }
    
            public IEnumerable<MovieImage> Data { get; set; }
    
            public int Columns { get; set; }
    
            public MovieAndDetailsViewModel(IEnumerable<MovieImage> movieImages)
            {
                Data = movieImages;
                
                Columns = 4;
            }
        }
    
        public class MovieSetsViewModel
        {
            public List<MovieListViewModel> Sets { get; set; }
    
            public MovieSetsViewModel()
            {
                Sets = new List<MovieListViewModel>();
            }
        }
    
        public class MovieListViewModel
        {
            public List<MovieImage> MovieImageList { get; set; }
    
            /* This gets updated while choosing a movie in DataGrid */
            public MovieImage SelectedMovie { get; set; }
    
            public MovieListViewModel()
            {
                MovieImageList = new List<MovieImage>();
                SelectedMovie = new MovieImage();
            }
        }
    
        public class MovieImage
        {
            public Uri SourcePath { get; set; }
            public string ID { get; set; }
        }
    }
