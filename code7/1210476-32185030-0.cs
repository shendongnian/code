        public class ViewModelLocator : INotifyPropertyChanged
        {
            // ViewModel of Database connection window
            private DbConViewModel _dbConViewModel;
            //ViewModel for Main window
            public MainViewModel Main { get; set; }
            //
            public static ViewModelLocator Instance
            {
                get { return Application.Current.Resources["Locator"] as ViewModelLocator; }
            }
            //Constructor
            public ViewModelLocator()
            {
                //this will automatically dispose the DbContext as soon as the code leaves the directive
                using (DbCon db = new DbCon())
                {                    
                    if (db.Database.Exists())
                    {
                        Main = new MainViewModel(DialogCoordinator.Instance, new PeopleService(), new StatusService(),
                            new UserService());
                    }
                    else
                    {
                        //this will execute the code in DoLongOperation() in an extra task, preventing the UI from freezing
                        Task.Factory.StartNew(() => DoLongOperation());
                    }
                }
            }
            private void DoLongOperation()
            {
                _dbConViewModel = new DbConViewModel(); 
            }
        }
