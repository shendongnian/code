    public DataForm()
    {
        InitializeComponent();
        InitializeAutocomplete(() => InitializeAutocomplete(tbName, "OwnerName", "Owners"));
        InitializeAutocomplete(() => InitializeAutocomplete(tbRemarks, "RemarkText", "Remarks"));
    }
    List<Action> autoCompleteInitializers = new List<Action>();
    private void ReinitializeAutocomplete()
    {
        foreach(var initializer in autoCompleteInitializers)
        {
            initializer();
        }
    }
    private void InitializeAutocomplete(Action init)
    {
        init();
        autoCompleteInitializers.Add(init);
    }
    private void InitializeAutocomplete(TextBox tb, string fieldName, string tableName)
    {
        tb.AutoCompleteMode = AutoCompleteMode.Suggest;
        tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
        tb.AutoCompleteCustomSource = new AutoCompleteStringCollection();
        using (SQLiteConnection dbconn = new SQLiteConnection())
        {
            dbconn.Open();
            using (SQLiteCommand dbcmd = dbconn.CreateCommand())
            {
                dbcmd.CommandText = String.Format("select {0} from {1}", fieldName, tableName);
                dbcmd.CommandType = CommandType.Text;
                using (SQLiteDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tb.AutoCompleteCustomSource.Add(reader[fieldName].ToString());
                    }
                }
            }
        }
    }
    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (bTransactionSuccess) ReinitializeAutocomplete();
    }
