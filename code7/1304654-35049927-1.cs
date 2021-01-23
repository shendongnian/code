    public class UserAccountData {
        private readonly DbContext _context;
        public UserAcctionData(DbContext context) { _context = context; }
        
        public Get(string username) {
            return from da in _context.table1
            from ra in _context.table2.Where(_ra => da.someID == _ra.someID).DefaultIfEmpty()
            from rg in _context.table3.Where(_rg => da.someID2 == _rg.someID2).DefaultIfEmpty()
            from re in _context.table4.Where(_re => da.someID3 == _re.someID3).DefaultIfEmpty()
            where da.UserName == username
            select new DumbStoragePoco
            {
                FirstName = ra.FirstName,
                Surname = ra.Surname,
                Email = da.UserName, 
            });
    }
