    public interface IService<T>
    {
        void Save(List<T> items); 
    }
    public class MemberService : IService<Member>
    {
         // same code as before
    }
