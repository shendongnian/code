    /// <summary>
    /// Assume you have special class to store users
    /// </summary>
    public class UserBdo
    {
        public int id1 { get; set; }
        public int id2 { get; set; }
        ......
    }
    public class PagingParams
    {
        public int CurrentPage { get; set; }
        public int PerPage { get; set; } = 10;
        /// <summary>
        /// How many without paging
        /// </summary>
        public int TotalResults { get; set; }
    }
    
    public class UsersBll
    {
        public IEnumerable<UserBdo> Search(int? id1, int? id2, int? id3, IEnumerable<string> searchTerms, PagingParams pp)
        {
            var results = db.Users.Include(u => u.table1).
                Include(u => u.table2).Include(u => u.table3).
                Include(u => u.table4).Include(u => u.table5).
                Where(u => u.Roles.Any(s => s.RoleId == VendorRole.Id));
            if (id1.HasValue)
            {
                results.Where(m => m.table1.First(a => a.id1 == id1) != null);
            }
            if (id2.HasValue)
            {
                results.Where(m => m.table1.First(a => a.id2 == id2) != null);
            }
            //results = ...
            pp.TotalResults = 100;
            return results.Skip((pp.CurrentPage  - 1) * pp.PerPage).Take(pp.PerPage).ToListAsync();
        }
    }
