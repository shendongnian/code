	// Message definitions
	public interface IMessage
	{
		Guid ID {get; set;}
	}
	public interface IEvent : IMessage
	{ }
	public interface ICommand : IMessage
	{ }
	public class DeleteUserCommand : ICommand
	{
		public Guid ID {get; set;}
		
		public Guid UserId {get; set;}
	}
	public class UserDeletedEvent : IEvent
	{
		public Guid ID {get; set;}
		
		public Guid UserId {get; set;}
	}
	// Repository definitions
	public interface IRepository
	{ }
	public interface IUserRepository : IRepository
	{
		void DeleteUser(Guid userId);
	}
	public UserRepository : IUserRepository
	{
		public void DeleteUser(Guid userId)
		{}
	}
	// Service definitions
	public interface IService
	{ }
	public class UserService : IService, IHandles<DeleteUserCommand>
	{
		public IUserRepository UserRepository {get; set;}
		
		public void Handle(DeleteUserCommand deleteUserCommand)
		{
			UserRepository.DeleteUser(deleteUserCommand.Id)
			
			//raise event
		}
	}
