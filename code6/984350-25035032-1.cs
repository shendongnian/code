    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo[] methods = typeof(User).GetMethods();
            foreach (var method in methods)
            {
                if (method.IsVirtual && !method.IsFinal)
                {
                    Console.WriteLine(method.Name);
                }
            }
            Console.ReadLine();
        }
    }
    public class User : IUser
    {
        public string Get(int id)
        {
            // some codes
            return null;
        }
        public virtual string GetData(int id)
        {
            // I want to find this method declared as virtual
            return null;
        }
    }
    public interface IUser
    {
        string Get(int id);
        string GetData(int id);
    }
