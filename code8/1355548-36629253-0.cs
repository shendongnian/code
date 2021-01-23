       [ServiceContract]
        public interface IService
        {
            [OperationContract]
            CustomResponse Test(string test);
        }
        public class CustomResponse { }
