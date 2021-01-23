    services.AddTransient<IMyInterface<CustomerSavedConsumer>, CustomerSavedConsumer>();
    services.AddTransient<IMyInterface<ManagerSavedConsumer>, ManagerSavedConsumer>();
    public interface IMyInterface<T> where T : class, IMyInterface<T>
    {
    	Task Consume();
    }
    public class CustomerSavedConsumer: IMyInterface<CustomerSavedConsumer>
    {
        public async Task Consume();
    }
    public class ManagerSavedConsumer: IMyInterface<ManagerSavedConsumer>
    {
        public async Task Consume();
    }
