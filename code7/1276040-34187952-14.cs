        public WriteToDatabase()
        {
            sql.OpenSqlConnection();
            InitializeComponent();
            this.UpdateInitialWeek();
            sql.CloseSqlConnection();
        }
