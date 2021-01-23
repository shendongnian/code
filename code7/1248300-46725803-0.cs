    using Prism.Commands;
    using Prism.Mvvm;
    using static System.String;
    public class LoginData : BindableBase
    {
        public LoginData()
        {
            DbAddr = DbName = DbUser = DbPw = "";
            TestDbCommand = new DelegateCommand(TestDbConnection, CanTestDbConnection)
                .ObservesProperty(() => DbAddr)
                .ObservesProperty(() => DbName)
                .ObservesProperty(() => DbUser)
                .ObservesProperty(() => DbPw);
        }
        public DelegateCommand TestDbCommand { get; set; }
        public bool CanTestDbConnection()
        {
            return !IsNullOrWhiteSpace(DbAddr)
                && !IsNullOrWhiteSpace(DbName)
                && !IsNullOrWhiteSpace(DbUser)
                && !IsNullOrWhiteSpace(DbPw);
        }
        public void TestDbConnection()
        {
            var t = new Thread(delegate () {
                Status = DatabaseFunctions.TestDbConnection(this);
            });
            t.Start();
        }
        private string _dbAddr;
        public string DbAddr
        {
            get => _dbAddr;
            set => SetProperty(ref _dbAddr, value);
        }
        ...
    }
