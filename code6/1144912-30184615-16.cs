	public partial class Model1 : ProxyDbContext
	{
		public Model1()
			: base("name=Model1", Manipulate)
		{
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="executing">true: the returned Expression will be executed directly, false: the returned expression will be returned as IQueryable&lt&gt.</param>
		/// <param name="expression"></param>
		/// <returns></returns>
		private static Expression Manipulate(bool executing, Expression expression)
		{
            // See the annotation about reexecuting the same visitor
            // multiple times in MyExpressionManipulator().Visit .
            // By executing the visitor only on executing == true,
            // and simply return expression; on executing == false,
            // you have the guarantee that an expression won't be
            // manipulated multiple times.
            // As written now, the expression will be manipulated
            // multiple times.
			return new MyExpressionManipulator().Visit(expression);
		}
		// Some tables
		public virtual DbSet<Parent> Parent { get; set; }
		public virtual IDbSet<Child> Child { get; set; }
