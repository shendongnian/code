     public class ListBoxTest
    {
        public string name { get; set; }
        public string id { get; set; }
    }
    public class PivotTest
    {
        public List<ListBoxTest> ListBoxTestlist { get; set; }
        public string header { get; set; }
    }
    public sealed partial class MainPage : Page
    {
        public List<PivotTest> PivotTestlist { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            PivotTestlist = new List<PivotTest>();
            PivotTest PivotTest1 = new PivotTest();
            PivotTest1.ListBoxTestlist = new List<ListBoxTest>();
            PivotTest1.ListBoxTestlist.Add(new ListBoxTest() { name = "name1", id = "id1" });
            PivotTest1.ListBoxTestlist.Add(new ListBoxTest() { name = "name2", id = "id2" });
            PivotTest1.header = "header1";
            PivotTestlist.Add(PivotTest1);
            PivotTest PivotTest2 = new PivotTest();
            PivotTest2.ListBoxTestlist = new List<ListBoxTest>();
            PivotTest2.ListBoxTestlist.Add(new ListBoxTest() { name = "name11", id = "id11" });
            PivotTest2.ListBoxTestlist.Add(new ListBoxTest() { name = "name22", id = "id22" });
            PivotTest2.header = "header2";
            PivotTestlist.Add(PivotTest2);
            this.DataContext = this;
           
        }
        private DependencyObject FindChildControl<T>(DependencyObject control, string ctrlName)
        {
            int childNumber = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < childNumber; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(control, i);
                FrameworkElement fe = child as FrameworkElement;
                // Not a framework element or is null
                if (fe == null) return null;
                if (child is T && fe.Name == ctrlName)
                {
                    // Found the control so return
                    return child;
                }
                else
                {
                    // Not found it - search children
                    DependencyObject nextLevel = FindChildControl<T>(child, ctrlName);
                    if (nextLevel != null)
                        return nextLevel;
                }
            }
            return null;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListBox listCont = FindChildControl<ListBox>(SchedulePivot, "ScheduleList") as ListBox;
            int count = listCont.Items.Count;
        }
    }
