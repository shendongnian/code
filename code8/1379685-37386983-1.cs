    public class MainPageViewModel : BindableBase
    {
        public MainPageViewModel()
        {
            dbList = new ObservableCollection<DBList>();
            Delete = new DelegateCommand(DeleteClicked);
            Edit = new DelegateCommand(EditClicked);
            AddAfterThisItem = new DelegateCommand(AddClicked);
            InsertDataForTest = new DelegateCommand(InsertClicked);
    
            //load data from db
            if (db.Table<DBList>().Count() != 0)
            {
                foreach (var entry in db.Table<DBList>())
                {
                    dbList.Add(new DBList { ID = entry.ID, Content = entry.Content });
                }
            }
        }
    
        public readonly ICommand Delete;
        public readonly ICommand Edit;
        public readonly ICommand AddAfterThisItem;
        public readonly ICommand InsertDataForTest;
    
        public ObservableCollection<DBList> dbList;
        public static string DB_PATH = Path.Combine(ApplicationData.Current.LocalFolder.Path, "database.sqlite");
        public static SQLite.Net.Platform.WinRT.SQLitePlatformWinRT SQLITE_PLATFORM = new SQLitePlatformWinRT();
        public SQLite.Net.SQLiteConnection db = new SQLite.Net.SQLiteConnection(SQLITE_PLATFORM, DB_PATH);
    
        private DBList item;
    
        public void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var gridview = sender as GridView;
            FlyoutBase.ShowAttachedFlyout(gridview);
            item = gridview.SelectedItem as DBList;
        }
    
        private void DeleteClicked()
        {
        }
    
        private void EditClicked()
        {
        }
    
        private void AddClicked()
        {
        }
    
        private void InsertClicked()
        {
            db.DeleteAll<DBList>();
            for (int i = 0; i < 300; i++)
            {
                DBList list = new DBList();
                list.ID = i;
                list.Content = "Item " + i;
                db.Insert(list);
                if (i == 299)
                {
                    foreach (var entry in db.Table<DBList>())
                    {
                        dbList.Add(new DBList { ID = entry.ID, Content = entry.Content });
                    }
                }
            }
        }
    }
