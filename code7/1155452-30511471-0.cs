    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var myTasks = new List<Task<BitmapImage>>();
            // Task<T>.Factory.StartNew starts the given method on a Thread Pool thread
            myTasks.Add(Task<BitmapImage>.Factory.StartNew(LoadPicture1));
            myTasks.Add(Task<BitmapImage>.Factory.StartNew(LoadPicture2));
            // The important part: Task.WhenAll waits asynchronously until all tasks
            // in the collection finished sucessfully. Only then, the lambda that is
            // given to the ContinueWith method is executed. The UI thread does not block
            // in this case.
            Task.WhenAll(myTasks)
                .ContinueWith(task =>
                              {
                                  foreach (var bitmapImage in task.Result)
                                  {
                                      var image = new Image { Source = bitmapImage };
                                      ImageStackPanel.Children.Add(image);
                                  }
                              },
                              TaskScheduler.FromCurrentSynchronizationContext());
        }
        private BitmapImage LoadPicture1()
        {
            return LoadImageFile("Picture1.jpg");
        }
        private BitmapImage LoadPicture2()
        {
            // Simulate that this loading process takes a little bit longer
            Thread.Sleep(1000);
            return LoadImageFile("Picture2.jpg");
        }
        private BitmapImage LoadImageFile(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = fileStream;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
        }
    }
