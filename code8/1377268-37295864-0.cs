	public class GlobalExceptionHandler: ExceptionHandler
	{
		private string _pvtMsg;
		private readonly object _lock = new object();
		public override void handle(ExceptionHandlerContext context)
		{
			lock(_lock)
			{
				//few if else conditions
				if()
				{
				}
				else if
				{
					_pvtMsg = "some value";
				}
				context.Result="Some random value depending upon if else execution";
			}
		}
	}
