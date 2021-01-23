    private static object MyDataLoadLock = new object();
    public List<object> MyData
    {
        get
        {
            return this.Cache["MyDatabaseCalculations"] as List<object>;
        }
        set
        {
            this.Cache["MyDatabaseCalculations"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (MyData == null)
        {
            lock (MyDataLoadLock)
            {
                if (MyData == null)
                {
                    MyData = GetDatabaseCalculations();
                }
            }
        }
    }
    private List<object> GetDatabaseCalculations()
    {
        System.Threading.Thread.Sleep(6500);
        return new List<object>();
    }
