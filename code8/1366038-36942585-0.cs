    private EntitiesContext _context;
    private EntitiesContext EntitiesContext
            {
                get
                {
                    if (_context == null)
                    {
                        _context = new EntitiesContext();
                         _context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s); //For debugging the SQL made by EF
                    }
                    return _context;
                }
                set { _context = value; }
            }
