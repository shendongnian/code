    List<MediaElement> mygif;
    List<Border> gborder;
    List<DoubleAnimation> anim2;
    List<bool> animsact;
    Dictionary<int, string> GifList = new Dictionary<int, string>();
    int _pos = 0;
    private int position
    {
        get
        {
            return _pos;
        }
        set
        {
            _pos = value;
            Console.WriteLine(_pos);
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        mygif = Enumerable.Range(0, 30).Select(d => new MediaElement()).ToList();
        gborder = Enumerable.Range(0, 30).Select(d => new Border()).ToList();
        anim2 = Enumerable.Range(0, 30).Select(d => new DoubleAnimation()).ToList();
        animsact = Enumerable.Range(0, 30).Select(d => false).ToList();
        GifCanvas = new Canvas();
        int brdr_height = 150;
        GifCanvas.Height = brdr_height * mygif.Count;
        for(int i = 0; i < mygif.Count; i++)
        {
            //Setup MediaElement
            mygif[i].UnloadedBehavior = MediaState.Play;
            mygif[i].LoadedBehavior = MediaState.Manual;
            mygif[i].MediaEnded += MediaEndedHandler;
            mygif[i].PreviewMouseLeftButtonDown += PreviewMouseLeftButtonDownHandler;
            mygif[i].MediaOpened += MainWindow_MediaOpened;
    
            //Setup Border
            gborder[i].BorderBrush = Brushes.White;
            gborder[i].BorderThickness = new Thickness(3, 3, 3, 3);
            gborder[i].CornerRadius = new CornerRadius(8, 8, 8, 8);
            gborder[i].Child = mygif[i];
            gborder[i].Width = 200;
            gborder[i].Height = brdr_height;
    
            GifCanvas.Children.Add(gborder[i]);
            Canvas.SetTop(gborder[i], (i * gborder[i].Height) + (bigspacer * i) - gborder[i].Height);
            Canvas.SetLeft(gborder[i], gborder[i].Width);
            //Comment the below line out to see if shows them all has an effect
            //gborder[i].Visibility = System.Windows.Visibility.Hidden;
        }
    
        ScrollViewer sv1 = new ScrollViewer();
        sv1.CanContentScroll = true;
        sv1.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        sv1.Height = GifBrowserCmd.Height;
        sv1.Content = GifCanvas;
        GifBrowserGrid.Children.Add(sv1);
        GifBrowserCmd.Content = GifBrowserGrid;
        GifBrowserCmd.Show();
        GifBrowserCmd.Deactivated += GifListCmd_Deactivated;
    }
    
    private void MediaOpened(object sender, RoutedEventArgs e)
    {
        MediaElement tmp = (MediaElement)sender;
        int tmpkey = 0;
        string searchstring = tmp.Source.AbsolutePath.ToString().Replace("%20", " ").Replace("/", @"\").Replace("\\", @"\");
        if(GifList.ContainsValue(searchstring))
        {
            tmpkey = GifList.FirstOrDefault(x => x.Value == searchstring).Key;
            tmpkey--;
        }
        TranslateTransform trans = new TranslateTransform();
        gborder[tmpkey].RenderTransform = trans;
        anim2[tmpkey] = new DoubleAnimation(gborder[tmpkey].Width, 0 - gborder[tmpkey].Width, TimeSpan.FromSeconds(.25));
        anim2[tmpkey].Completed += AnimationCompleted;
        if(tmpkey == 0)
        {
            gborder[(tmpkey)].Visibility = System.Windows.Visibility.Visible;
            trans.BeginAnimation(TranslateTransform.XProperty, anim2[(tmpkey)]);
            position++;
        }
    }
    
    private void AnimationCompleted(object sender, EventArgs e)
    {
        if(position < mygif.Count)
        {
            gborder[position].Visibility = System.Windows.Visibility.Visible;
            gborder[position].RenderTransform.BeginAnimation(TranslateTransform.XProperty, anim2[position++]);
        }
    }
    
    private void PreviewMouseLeftButtonDownHandler(object sender, MouseButtonEventArgs e)
    {
        MediaElement tmp = (MediaElement)sender;
        int tmpkey = 0;
        string searchstring = tmp.Source.AbsolutePath.ToString().Replace("%20", " ").Replace("/", @"\").Replace("\\", @"\");
        if(GifList.ContainsValue(searchstring))
        {
            tmpkey = GifList.FirstOrDefault(x => x.Value == searchstring).Key;
            LoadGifDetailScreen(tmpkey);
        }
        else
        {
            MessageBox.Show("Couldn't find gif in Dictionary!");
        }
    }
    
    private void MediaEndedHandler(object sender, RoutedEventArgs e)
    {
        MediaElement tmp = (MediaElement)sender;
        int tmpkey = 0;
        string searchstring = tmp.Source.AbsolutePath.ToString().Replace("%20", " ").Replace("/", @"\").Replace("\\", @"\");
        if(GifList.ContainsValue(searchstring))
        {
            tmpkey = GifList.FirstOrDefault(x => x.Value == searchstring).Key;
        }
        mygif[tmpkey].Position = new TimeSpan(0, 0, 1);
        mygif[tmpkey].Play();
    }
