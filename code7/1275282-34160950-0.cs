    public void ImportBatch(TextFieldParser parser)
    {        
        string[] fields = parser.ReadFields();
        MyService.AddMyEntity(fields);
    }
    int _batchCount = 0;
    public myDbContext _db;
    public myDbContext Db
    {
        get
        {
            // If batchCount > 50 or _db is not created we need to create _db
            if (_db == null || _batchCount > 50)
            {
                // If db is  already created _batchcount > 50
                if (_db != null)
                {
                    _db.ChangeTracker.DetectChanges();
                    _db.SaveChanges();
                    _db.Dispose();
                }
                _db = new myDbContext();
                _db.Configuration.AutoDetectChangesEnabled = false;
                _batchCount = 0;
            }
            batchCount++;
            return _db;
        }
    }
