    ...
    
    private static readonly DataBaseService _instance;
    static DataBaseService()
    {
        _instance = new DataBaseService();
        Initilize();
    }
    private static void Initilize()
    {
        try
        {
            _instance.myConnection = new SqlConnection(ConnectionString);
            _instance.myConnection.Open();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error while connecting to DB: " + ex.Message);
            return;
        }
    }
    
    ...
