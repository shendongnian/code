    namespace InterfaceExample
    {
        public interface IDef
        {
            void FDef();
        }
        public interface IImp
        {
            void FImp();
        }
        public class AbstractImplementation<T> where T : IImp
        {
            // This class implements default behavior for interface IDef
            public void FAbs(IImp implementation)
            {
                implementation.FImp();
            }
        }
        public class MyImplementation : AbstractImplementation<MyImplementation>, IImp, IDef
        {
            public void FDef()
            {
                FAbs(this);
            }
            public void FImp()
            {
                // Called by AbstractImplementation
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                MyImplementation MyInstance = new MyImplementation();
               MyInstance.FDef();
            }
        }
    }
