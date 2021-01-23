    public interface IService
     {
       IList<Users> GetUserDetails(int userId);
    
     }
------------------------------------------------
 
    public class Service : IService
     {
    
     private readonly IRepository<Users> _userRepository;
    
     public Service (IUnitOfWork unitOfWork)
            {
               _unitOfWork = unitOfWork;
    	   _userRepository=_unitOfWork.GetRepository<Users>();
            }
    
    	public  IList<Users> GetUserDetails(int userId)
    	{
    		return _userRepository.GetAll();
    
    	}
    
     }
