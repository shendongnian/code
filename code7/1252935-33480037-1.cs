    public class DbSeedData
    {
        private MyDb _context;
        public DbSeedData(MyDb db)
        {
            _context = db;
        }
        public void EnsureSeedData()
        {
            if (!_context.Entities.Any())
            {
                {
                    _context.Entities.Add(
                        new Entity{EntityName="blabla" },
                        new Entity{EntityName="blabla2" }
                     )
                }
            }
        }
            
