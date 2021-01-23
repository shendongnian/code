        public List<SimpleItem> GetAllItemsFromQuery(IEnumerable<tbl_color> table, Int32 skip)
		{
			List<SimpleItem> SimpleItemList = new List<SimpleItem>();
			SimpleItemList = table.Where(p => p.IsActive).OrderBy(p => p.Name).Select(p => new SimpleItem { id = p.Id, Name = p.Name, IsActive = p.IsActive }).Skip(skip).Take(30).Distinct().ToList();
			return SimpleItemList;
		}
