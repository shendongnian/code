    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
        // namespace ...
    public sealed partial class Basket : Page
    {
        private static ObservableCollection<Menu.PassedData> passedData = new ObservableCollection<Menu.PassedData>();
        public ObservableCollection<Menu.PassedData> PassedData
        {
            get { return passedData; }
            set { passedData = value; }
        }
        /*Events*/
        public event PropertyChangedEventHandler PropertyChanged;
        /*Methods*/
        /// Fires PropertyChangedEventHandler, for bindables
        protected void OnPropertyChanged(string name)
        {
            var ev = PropertyChanged;
            if (ev != null)
            {
                ev(this, new PropertyChangedEventArgs(name));
            }
        }
        public Basket()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Menu.PassedData data = e.Parameter as Menu.PassedData;
            /**    ItemChosentxt.Text = data.Name;
                ItemChosentxt2.Text = data.Name;
                ItemChosentxt3.Text = data.Name;
                ItemChosentxt4.Text = data.Name;**/
            if (data != null)
            {
                PassedData.Add(data);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu));
        }
    }
}
