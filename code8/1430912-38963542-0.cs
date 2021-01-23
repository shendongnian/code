        ...
        public interface IFactory
        {
            IService<IResult> GetService(string documentType);
        }
        public class MyFactory : IFactory
        {
            public IService<IResult> GetService(string documentType)
            {
                //Cast needed to address the error...
                return (IService<IResult>) new ServiceA<ResultA>();
            }
        }
