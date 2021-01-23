     public List<Test> TestList = new List<Test>();
        public MainPage()
        {
            this.InitializeComponent();
            TestList.Add(new Test() {wpn="BB",sname="BBB",Image = new BitmapImage(new Uri("ms-appx:///Capture.PNG")),Color=new SolidColorBrush(Colors.Red)});
            TestList.Add(new Test() { wpn = "CC", sname = "CCC", Image = new BitmapImage(new Uri("ms-appx:///Capture.PNG1")), Color = new SolidColorBrush(Colors.Green) });
            TestList.Add(new Test() { wpn = "AA", sname = "AA", Image = new BitmapImage(new Uri("ms-appx:///Capture.PNG2")), Color = new SolidColorBrush(Colors.Orange) });
            List<Test> MyListSort = new List<Test>();
            MyListSort=TestList.OrderBy<Test, string>(Item => Item.wpn.Substring(0)).ToList();
            ivGridView.ItemsSource = MyListSort;
        }
