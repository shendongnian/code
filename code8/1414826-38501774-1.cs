    public sealed partial class MainPage : Page
    {
        public List<String> List;
        public List<String> List2;
        private object PreviousFocusItem;
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List = new List<string> { "data1_GridView1", "data2_GridView1", "data3_GridView1" };
            List2 = new List<string> { "data1_GridView2", "data2_GridView2", "data3_GridView2" };
            myGridView.ItemsSource = List;
            myGridView2.ItemsSource = List2;
            rootGrid.GotFocus += Grid_GotFocus;
            rootGrid.LostFocus += Grid_LostFocus;
            base.OnNavigatedTo(e);
        }
        private void Grid_LostFocus(object sender, RoutedEventArgs e)
        {
            PreviousFocusItem = e.OriginalSource;
        }
        private void Grid_GotFocus(object sender, RoutedEventArgs e)
        {
            //get the previous focus Element and current focus Element.
            var previous = PreviousFocusItem as UIElement;
            var current = e.OriginalSource as UIElement;
            //got focus logic
            if ((!IsElementInsideGridView(myGridView, previous)) &&IsElementInsideGridView(myGridView,current))
            {
                //gridView got focus as a whole, put your codes here:
                output.Text += "Got Focus+1 \n";
            }
            //lost focus logic
            if ((!IsElementInsideGridView(myGridView, current)) &&(IsElementInsideGridView(myGridView,previous)) )
            {
                //gridView lost focus as a whole, put your codes here:
                output.Text += "Lost Focus+1 \n";
            }
        }
        private bool IsElementInsideGridView(GridView gridView,UIElement element)
        {
            Point topLeft = gridView.TransformToVisual(this).TransformPoint(new Point());
            Rect rectBounds = new Rect(topLeft.X, topLeft.Y, gridView.ActualWidth, gridView.ActualHeight);
            IEnumerable<UIElement> hits = VisualTreeHelper.FindElementsInHostCoordinates(rectBounds, element);
            if (hits == null || hits.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
