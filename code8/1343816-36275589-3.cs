     public ObservableCollection<Test> TestOC = new ObservableCollection<Test>();
        public MainPage()
        {
            this.InitializeComponent();
            TestOC.Add(new Test() {wpn="BB",sname="BBB",Image = new BitmapImage(new Uri("ms-appx:///Capture.PNG")),Color=new SolidColorBrush(Colors.Red)});
            TestOC.Add(new Test() { wpn = "CC", sname = "CCC", Image = new BitmapImage(new Uri("ms-appx:///Capture.PNG")), Color = new SolidColorBrush(Colors.Green) });
            TestOC.Add(new Test() { wpn = "AA", sname = "AA", Image = new BitmapImage(new Uri("ms-appx:///Capture.PNG")), Color = new SolidColorBrush(Colors.Orange) });
            var SortResult = TestOC.OrderBy(a => a.wpn);           
            ivGridView.ItemsSource =SortResult;
        }
