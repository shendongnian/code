        public class tbl_color: BaseEntity
    	{
    		
    	}
    
    	public class BaseEntity
    	{
    		public bool IsActive { get; set; }
    		public string Name { get; set; }
    		public int Id { get; set; }
    	}
    
        public List<SimpleItem> GetAllItemsFromQuery<T>(IEnumerable<T> table, Int32 skip) where T : BaseEntity
		{
			List<SimpleItem> SimpleItemList = new List<SimpleItem>();
			SimpleItemList = table.Where(p => p.IsActive).OrderBy(p => p.Name).Select(p => new SimpleItem { id = p.Id, Name = p.Name, IsActive = p.IsActive }).Skip(skip).Take(30).Distinct().ToList();
			return SimpleItemList;
		}
