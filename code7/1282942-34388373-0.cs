    public sealed partial class MainPage : Page
    {
        ObservableCollection<listText> list = new ObservableCollection<listText>();
        static int selectedcount = -1;
    public MainPage()
    {
        this.InitializeComponent();
        mylist.ItemsSource = list;
    }
    class listText
    {
        public string listtxt { get; set; }
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        list.Clear();
        list.Add(new listText { listtxt = "Item1" });
        list.Add(new listText { listtxt = "Item2" });
        mylist.SelectedIndex = selectedcount;
    }
    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (mylist.SelectedIndex)
        {
            case 0:
                selectedcount = 0;
                this.Frame.Navigate(typeof(Item1));                    
                break;
            case 1:
                selectedcount = 1;
                this.Frame.Navigate(typeof(Item2));
                break;
            default:
                selectedcount = 0;
                this.Frame.Navigate(typeof(Item1));
                break;
        }
    }
