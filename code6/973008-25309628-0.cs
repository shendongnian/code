        static void Main(string[] args)
        {
            var travelRequestRepository = new Repository<TravelRequest>();
            var userRepository = new Repository<User>();
            test(travelRequestRepository,userRepository);
            Console.ReadLine();
            
   
        }
        static void test(IRepository<ITravelRequest> repository, IRepository<IUser> userRepositor)
        {
        }
        public interface IBaseEntity{}
        
        public interface IRepository<out T> where T : IBaseEntity
        {}
        
        public class Repository<T>:IRepository<T> where T:IBaseEntity
        {
        }
        public interface ITravelRequest : IBaseEntity
        {}
        public interface IUser : IBaseEntity
        {}
        public class TravelRequest : ITravelRequest
        {}
        public class User : IUser
        { }
