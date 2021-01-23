    public partial class MyDbContext : DbContext 
    {
        //...
        public virtual int SetUserContext(string modifierId)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetUserContext", modifierId);  
        }
    }
    public class UserService 
    {
        private MyDbContext m_dataContext;
        public UserService(MyDbContext dataContext)
        {
            m_dataContext = dataContext;
        {
        public User CreateUser(string firstName, string lastName, DateTime birthDate, int modifiedId) // list other parameters here
        {
            using (var transaction = new TransactionScope()) // this creates a new transaction
            {
                m_dataContext.Users.Add(new User()
                {
                    //...
                });
                // instead of passing modified id into save changes, you can just call your stored procedure here
                m_dataContext.SetUserContext(modifiedId);
                // and then call the regular save changes
                m_dataContext.SaveChanges();
                transaction.Complete(); // this commits the transaction
            }
        }
    }
