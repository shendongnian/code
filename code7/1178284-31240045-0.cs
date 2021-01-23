    public FormExemple : Form
    {
        protected string conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb";
        protected OleDbConnection connection;
        protected OleDbDataAdapter adapter;
        ....
    
        Window_Load()
        {
            connection = new OleDbConnection(conStr);
            ...
            adapter.Fill(dTable);
    
            cb = new OleDbCommandBuilder(adapter);
            adapter.InsertCommand = cb.GetInsertCommand();
            //and other commands
            ...
        }
    
        Button_Click()
        {
            ...
            adapter.Update(dTable)
            ...
        }
    }
