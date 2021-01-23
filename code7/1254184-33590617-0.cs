    public interface IChatService
    {
        void OnConnected(Guid userId, string connectionId, HubConnectionContext clients);
        void OnDisconnected(Guid userId, string connectionId);
        void Broadcast(string message, string username, HubConnectionContext clients);
    }
	
	public class ChatService : IChatService
	{
		private readonly IUnitOfWork _unitOfWork;
		public UserChatService(IUnitOfWork unitOfWork) {
			_unitOfWork = unitOfWork;
		}
		public void OnConnected(Guid userId, string connectionId, HubConnectionContext clients) { 
			//Perform other operation using _unitOfWork
		}
		public void OnDisconnected(Guid userId, string connectionId) {
			//Perform other operation using _unitOfWork
		}
		public void Broadcast(string message, string username, HubConnectionContext clients) { 
			//Perform other operation using _unitOfWork and HubConnectionContext
            //broadcast message to other connected clients
            clients.others.broadcast(message);
		}
    }
