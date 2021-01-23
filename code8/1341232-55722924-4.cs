    public class FakeModel
    {
        public FakeModel(Guid id, string value)
        {
            Id = id;
            Value = value;
        }
    
        public Guid Id { get; }
        public string Value { get; private set; }
    
        public async Task UpdateAsync(string value)
        {
            Value = value;
            var mediator = ServiceLocator.ServiceProvider.GetService<IMediator>();
            await mediator.Send(new FakeModelUpdated(this));
        }
    }
