	public class TicTacToeViewModel
	{
		private readonly BoardState _board;
		public TicTacToeViewModel()
		{
			_board = new BoardState();
			MoveTokenCommand = new DelegateCommand(MoveToken, CanMoveToken);
			ResetBoardCommand = new DelegateCommand(_board.Reset);
			
			board.StateUpdates(state => UpdatePresentation(state));
		}
	
		public DelegateCommand MoveTokenCommand { get; private set;}
		public DelegateCommand ResetBoardCommand { get; private set;}
	
	
		private void MoveToken()
		{
			var token = CurrentToken;
			var location = ActiveLocation;
			var cmd = new PlaceTokenCommand(token, location);
			_board.PlaceToken(cmd);
		}
	
		private bool CanMoveToken()
		{
			//?
		}
	}
