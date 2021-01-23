    public class BaseClass
    {
       //No constructor is OK
    }
    public class DeriveClass : BaseClass
    {
       //No constructor is OK
    }
    class Program
    {
        static void Main(string[] args)
        {
            DeriveClass dc = new DeriveClass(); 
        }
    }
