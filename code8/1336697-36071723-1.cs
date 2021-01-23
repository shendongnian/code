	public class RestaurantRepository : IRestaurantRepository
	{
		private readonly IContext _context;
		public RestaurantRepository(IContext context)
		{
			_context = context;
		}
		// added async and await
		public async Task<ApiResult> GetRestaurantsByOutcode(string outcode)
		{
			return await _context.GetRestaurantsByOutcode(outcode);
		}
		// added async and await
		public async Task<List<Restaurant>> GetSortedRestaurantsByOutcode(string outcode)
		{
			// here you were not using await but then using result even though you were calling into a method marked as async which in turn used an await. this is where you deadlocked but this the fix.
			return (await _context.GetRestaurantsByOutcode(outcode)).Restaurants
				.OrderBy(x => x.Name).ToList();
		}
	}
