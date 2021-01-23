    public class CustomerSavedConsumer: IMyInterface<CustomerSavedConsumer>
    {
        public async Task Consume();
    }
    public class ManagerSavedConsumer: IMyInterface<ManagerSavedConsumer>
    {
        public async Task Consume();
    }
