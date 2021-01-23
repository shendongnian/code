    public partial class CountyRepository : ICountyRepository
    {
        private readonly Context _context;
        public CountyRepository(IContext context)
        {
            _context = context as Context;
        }
        public County Get(int id)
        {
            return _context.County.FirstOrDefault(x => x.CountyID == id);
        }
        public County GetByCompanyCountyID(int id)
        {
            return _context.County.FirstOrDefault(x => x.CountyID == id);
        }
        public IList<County> ListOfCounties()
        {
            return _context.County.ToList()
                .OrderBy(x => x.CountyName)  
                .ToList();
        }
        public void Delete(County county)
        {
            _context.County.Remove(county);
        }
        public County Add(County county)
        {
            _context.County.Add(county);
            return county;
        }
        public County SearchByName(string county)
        {
            return _context.County.FirstOrDefault(x => x.CountyName == county);
        }
    }
