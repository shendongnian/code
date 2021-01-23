    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SendService>().As<ISendService>();
            builder.RegisterType<CustomerService>()
                .As<ICustomerProcessingUnit>()
                .WithParameter("myUrl", AppSettings.Default.MyUrl);
            var container = builder.Build();
            var customerService = container.Resolve<ICustomerProcessingUnit>();
        }
    }
    public class SendService : ISendService
    {
    }
    public interface ISendService
    {
    }
    public interface ICustomerProcessingUnit
    {
        Task ProcessAsync();
    }
    public abstract class CustomerProcessingUnitBase : ICustomerProcessingUnit
    {
        public abstract Task ProcessAsync();
        public void Process()
        {
            this.ProcessAsync().Wait();
        }
    }
    public class CustomerService : CustomerProcessingUnitBase
    {
        private string myUrl;
        private readonly ISendService sendService;
        public CustomerService(ISendService sendService, string myUrl)
        {
            this.sendService = sendService;
            this.myUrl = myUrl;
        }
        public override Task ProcessAsync()
        {
            throw new NotImplementedException();
        }
    }
