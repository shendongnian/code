		private IQueryable<MyJoin<T>> Prepare<T>(IQueryable<MyJoin<T>> myJoin, System.Linq.Expressions.Expression<Func<MyJoin<T>, bool>> clause) {
			return myJoin
				.Where(clause)
				.OrderBy(x=> x.B.Date)
				.Take(1)
				.DefaultIfEmpty();
		}
