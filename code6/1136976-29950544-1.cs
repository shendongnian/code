    namespace SomeSharedNamespace
    {
        public interface IProduct
        {
            //shared properties you need
        }
    }
    namespace LiveService
    {
        public partial class Product : IProduct
        {
            //implement interface
        }
    }
    namespace TestService
    {
        public partial class Product : IProduct
        {
            //implement interface
        }
    }
