    public interface IUserService
    {
     	employee LoggedEmployee { get; set; }
       	List<int> UserRoles { get; set; }
       	bool LoggedIn { get; set; }
       	void UpdatePassword(int idEmployee, string password);
        ...
    }
    Public Class UserService :  IUserService
    {
    	Public void UpdatePassword(int idEmployee, String password)	{	}
            }
