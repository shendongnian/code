        public IQueryable<ItemDTO> RepGetItems(string inOut, string planFact)
        {
            return GetItemsWithCategory().
                Where(i => i.InOut.Equals(inOut)).
                Where(i => i.PlanFact.Equals(planFact));
        }
        public static class QueryExtensions
        {
            public static IQueryable<ItemDTO> ForYear(this IQueryable<ItemDTO> query, int year)
            {
                return query.Where(i => i.DateTime.Year.Equals(year));
            }
            public static IQueryable<ItemDTO> ForMonth(this IQueryable<ItemDTO> query, int month)
            {
                return query.Where(i => i.DateTime.Month.Equals(month));
            }
        }
