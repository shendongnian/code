    namespace ConsoleApplication5
    {
    public class PetaPocoUnitOfWork : IUnitOfWork
    {
        private readonly Transaction _petaTransaction;
        private readonly Database _db;
        public PetaPocoUnitOfWork(string connectionString)
        {
            _db = new Database(connectionString);
            _petaTransaction = new Transaction(_db);
        }
        public void Dispose()
        {
            _petaTransaction.Dispose();
        }
        public Database Db
        {
            get { return _db; }
        }
        public void Commit()
        {
            _petaTransaction.Complete();
        }
    }
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Database Db { get; }
    }
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork GetUnitOfWork(string connectionString);
    }
    public class PetaPocoUnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IUnitOfWork GetUnitOfWork(string connectionString)
        {
            return new PetaPocoUnitOfWork(connectionString);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var unitOfWorkProvider = new PetaPocoUnitOfWorkProvider();
            using (var uow = unitOfWorkProvider.GetUnitOfWork(""))
            {
                var errorNumber = new SqlParameter("@ErrorNumber", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var errorSeverity = new SqlParameter("@ErrorSeverity", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var errorState = new SqlParameter("@ErrorState", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var errorProcedure = new SqlParameter("@ErrorProcedure", SqlDbType.NVarChar) { Direction = ParameterDirection.Output, Size = 128 };
                var errorLine = new SqlParameter("@ErrorLine", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var errorMessage = new SqlParameter("@ErrorMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output, Size = 4000 };
                var sqlScript = Sql.Builder.Append(";EXEC @0 " +
                               " @@Uid = @1," +
                               " @@ErrorNumber = @2 OUTPUT," +
                               " @@ErrorSeverity = @3 OUTPUT," +
                               " @@ErrorState = @4 OUTPUT," +
                               " @@ErrorProcedure = @5 OUTPUT," +
                               " @@ErrorLine = @6 OUTPUT," +
                               " @@ErrorMessage = @7 OUTPUT",
                "[Schema].[USP_BlaDiBla]",
                new Guid("1E454A42-CC41-4FA1-BE91-1F7689986A23").ToString(),
                errorNumber,
                errorSeverity,
                errorState,
                errorProcedure,
                errorLine,
                errorMessage
               );
                var result = uow.Db.SingleOrDefault<object>(sqlScript);
            }
        }
    }
    }
