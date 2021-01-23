        public IQueryable<int> GetItems(ItemsCriteria  criteria)
        {
            var q = GetAllDataQueryable();
            if (criteria.RemoveZeroes) q = q.Where(x => x != null)
            return q;
        }
