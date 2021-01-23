    public interface IBaseObjectWorker
    {
        int DoWork(BaseObject obj);
    }
    [Export(contractType: typeof(IBaseObjectWorker), contractName: "UnitTestProject1.Derived1")]
    public class DerivedObject1Worker : IBaseObjectWorker
    {
        public int DoWork(BaseObject obj)
        {
            return 1;
        }
    }
    [Export(contractType: typeof(IBaseObjectWorker), contractName: "UnitTestProject1.Derived2")]
    public class DerivedObject2Worker : IBaseObjectWorker
    {
        public int DoWork(BaseObject obj)
        {
            return 2;
        }
    }
