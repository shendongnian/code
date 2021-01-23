	public class SomeClass
	{
		private IEmailSender _sender;
		public SomeClass(IEmailSender sender)
		{
			_sender = sender;
		}
	
		public void Foo()
		{
			// do smth useful
			_sender.Send(new Email());
		}
	}
