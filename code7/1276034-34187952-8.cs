        public void WriteToDatabase()
        {
            sql.OpenSqlConnection();
            InitializeComponent();
            this.UpdateInitialWeek();
            sql.CloseSqlConnection();
        }
