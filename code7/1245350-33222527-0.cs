	public class LibraryException : Exception
	{
		public int ErrorCode { get; private set; }
		public LibraryException(int errorCode, string message)
			: base(message)
		{
			ErrorCode = errorCode;
		}
	}
