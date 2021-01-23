	
	public class DeleteUserHandler
	{
		public void OnUserDeleted(object sender, EventArgs args)
		{
			string userName = Event.ExtractParameter<string>(args, 0);
			...
		}
	}
	
