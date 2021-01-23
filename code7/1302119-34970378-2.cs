    static class QueryExtensions {
        public static IQueryable<MyRowType> PrepareDependents(this IQueryable<MyRowType> q) {
            return q.Include(r => r.RelatedTableA)
                    .Include(r => r.RelatedTableB)
                    .Include(r => r.RelatedTableC);
        }
    }
