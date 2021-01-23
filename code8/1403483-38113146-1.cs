    public class MyServiceClient : ClientBase<IService>, IService
    {
        public string GetData(int value)
        {
            return base.Channel.GetData(value);
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            return base.Channel.GetDataUsingDataContract(composite);
        }
    }
