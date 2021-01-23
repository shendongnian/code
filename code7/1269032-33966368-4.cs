    public partial class MainWindow : Window
    {
        Canvas _root = new Canvas();
        public MainWindow()
        {
            InitializeComponent();
            _root = new Canvas();
            AddChild(_root);
            //ScrollViewer 1
            ScrollViewer sv = new ScrollViewer();
            sv.Height = 400;
            sv.Width = 600;
            //ScrollerViewer 2
            ScrollViewer sv2 = new ScrollViewer();
            sv2.Height = 400;
            sv2.Width = 200;
            // Will be set later as Content of both Scrollviewers
            Canvas canvas = new Canvas();
            canvas.Width = Width;
            canvas.Height = Height;
            canvas.Background = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            // rectangle to be displayed on the canvas 
            Canvas rect = new Canvas();
            rect.Height = 100;
            rect.Width = 100;
            rect.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            canvas.Children.Add(rect);
            canvas.Measure(new Size(Width, Height));
            canvas.Arrange(new Rect(0, 0, Width, Height));
            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)Width, (int)Height, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(canvas);
            sv.Content = new Image { Source = bitmap };
            sv2.Content = new Image { Source = bitmap };
            sv.HorizontalScrollBarVisibility = sv.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            sv2.HorizontalScrollBarVisibility = sv.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            _root.Children.Add(sv);
            _root.Children.Add(sv2);
            Canvas.SetLeft(sv, 0);
            Canvas.SetLeft(sv2, 900);
        }
    }
