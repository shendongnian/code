    public enum UserAccessLevel
    {
        None,
        Employee,
        Manager
    }
    public interface IUser
    {
         string Name { get; }
         string UserName { get; }
         UserAccessLevel AccessLevel { get; }
    }
    public interface IMenuLoader
    {
         void LoadMenu()
    }
    public class MenuLoaderFactory()
    {
         public IMenuLoader(UserAccesLevel accesLevel)
         {
             IMenuLoader menuLoader = null;
             
             switch (accesLevel)
             {
                 case UserAccessLevel.Employee
                      menuLoader = new EmployeeMenuLoader();
                      break;
                 case UserAccessLevel.Manager
                      menuLoader = new ManagerMenuLoader();
             }
             
             return menuLoader ;   
         }
    }
    public sealed class EmployeeMenuLoader: IMenuLoader {...}
    public sealed class ManagerMenuLoader: IMenuLoader {...}
