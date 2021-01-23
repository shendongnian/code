        public class NetworkViewModel : INotifyPropertyChanged, ICommand
        {
            private ObservableCollection<Person> _networkList1 = new ObservableCollection<Person>();
            public event EventHandler CanExecuteChanged;
            public ObservableCollection<Person> NetworkList1
            {
                get { return _networkList1; }
                set { _networkList1 = value; RaisePropertyChanged("NetworkList1"); }
            }
            public NetworkViewModel()
            { }
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {
                String dbConnectionString = @"Data Source =movieprepper.sqlite;";
                SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
                sqliteCon.Open();
                var transaction = sqliteCon.BeginTransaction();
                String DeleteQuery = "delete from networking";
                SQLiteCommand DeleteCommand = new SQLiteCommand(DeleteQuery, sqliteCon);
                DeleteCommand.ExecuteNonQuery();
                foreach (Person p in _networkList1)
                {
                    String Query = "insert into networking (firstname, lastname) values ('" + p.FirstName + "','" + p.LastName + "')";
                    SQLiteCommand Command = new SQLiteCommand(Query, sqliteCon);
                    Command.ExecuteNonQuery();
                }
                transaction.Commit();
                sqliteCon.Close();
            }
        }
