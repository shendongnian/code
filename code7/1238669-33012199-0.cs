	public inteface IErrorHandler
	{
		void HandleError(string errorMessage);
	}
	
	public class ErrorHandler : IErrorHandler
	{
		public void HandleError(string errorMessage)
		{
			Console.WriteLine(errorMessage);
		}
	}
