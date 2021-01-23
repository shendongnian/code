    namespace App10
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                var list = new ObservableCollection<string>();
                for (int i = 0; i < 10; i++)
                {
                    list.Add("Item " + i);
    
                }
                listView.ItemsSource = list;
            }
        }
    }
