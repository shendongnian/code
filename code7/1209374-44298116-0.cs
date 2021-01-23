	public class MyHub : Hub
	{
		readonly IState _state;
		public MyHub(IState state)
		{
			_state = state;
		}
	}
