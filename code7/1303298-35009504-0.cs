    public interface IGetUserQuery
    {
        User Execute(string username, string password);
    }
    
    public class GetUserQuery : IGetUserQuery
    {
        public User Execute(string username, string password)
        {
            // your code
        }
    }
    
    CREATE PROCEDURE uspGetUser (@username nvarchar(50),@password nvarchar(50))
    AS
    select type from tbllogin where username=@username and password=@password
    
    public interface IAddUserCommand 
    {
        void Execute(string username, string password, string type);
    }
    
    public class AddUserCommand : IAddUserCommand 
    {
       public void Execute(string username, string password, string type)
       {
           // your code
       }
    }
    
    CREATE PROCEDURE uspAddUser (@username nvarchar(50),@password nvarchar(50),@type varchar(50),@status varchar(50))
    AS
    insert into tbllogin  values(@username,@password,@type)
    
