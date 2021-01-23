    public class TheDBEntities
    {
        private TheDBEntities _context = new TheDBEntities();
        protected TheDBEntities Context { get; private set; }
        protected TheDataContext()
        {
            
            Context = _context;
        }
        protected void SaveChanges()
        {
            Context.SaveChanges();
        }
        protected void SaveChangesAsync()
        {
            Context.SaveChangesAsync();
        }
    }
    public class DBBusinessLayer: TheDBEntities
    {
        public DBBusinessLayer() { }
        public void GetData(int id)
        {
            // use it here Context.<yourentities>
        }
    }
