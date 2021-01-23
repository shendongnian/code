    public sealed partial class BasketPage : Page, INotifyPropertyChanged
    {
        private MobileServiceCollection<Information, Information> tempItem;
        private ObservableCollection<Information> Items{get;private set;}
        private ObservableCollection<Information> RefreshedItems{get;private set;}
        private IMobileServiceTable<Information> informationTable = App.MobileService.GetTable<Information>();
        private Information selectedInformation;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public BasketPage()
        {
            this.InitializeComponent();
            this.Items = new ObservableCollection<Information>();
            this.RefreshedItems = new ObservableCollection<Information>();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            getListData();
            base.OnNavigatedTo(e);
        }
        private async void getListData()
        {
            var query = App.conn.Table<Information>();
            foreach (var item in query)
            {
                tempItem = await informationTable
                    .Where(todoItem => todoItem.Id == item.Name)
                    .ToCollectionAsync();
                RefreshedItems.Add(tempItem.ElementAt(0));
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
        private void CollectedItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selectedInformation = (Information)e.ClickedItem;
            Frame.Navigate(typeof(MediaViewPage), selectedInformation);
        }
        private void CollectedItemsListView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            var item = string.Join(",", e.Items.Cast<Information>().Select(i => i.Id));
            e.Data.SetText(item);
            e.Data.RequestedOperation = DataPackageOperation.Move;
        }
        private void TrashButton_DragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                e.AcceptedOperation = DataPackageOperation.Move;
            }
        }
        private async void TrashButton_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                var id = await e.DataView.GetTextAsync();
                var query = App.conn.Table<Information>();
                var itemToDelete = query.Where(p => p.Name == id).FirstOrDefault();
                RefreshedItems.Remove(itemToDelete);
                App.conn.Delete(itemToDelete);
                App.conn.Commit();   
            }
        }
    }
