    [TestClass]
	public class Test
	{
		private ClientContext ctx;
		
		
		[TestInitialize]
		public void Init()
		{
			ctx = GetContext();
		}
		
		[TestMethod]
		public void Delete_Sp_List()
		{
			ctx = tf.GetContext();
			List list = ctx.Web.Lists.GetByTitle("StackTicketList");
			list.DeleteObject();
			ctx.ExecuteQuery();
		}	
	}
