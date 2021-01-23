		static void Main(string[] args) {			
			var objects = new List<Test>();
			GetOrderedCollection(objects, x => x.Name);
		}
		class Test {
			public string Name { get; set; }
		}
		static IEnumerable<TEntity> GetOrderedCollection<TEntity>(IEnumerable<TEntity> objects, Func<TEntity, object> orderBy) {
			return objects.OrderBy(orderBy);
		}
