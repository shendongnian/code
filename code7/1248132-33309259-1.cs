    public class FooViewModel : IFooViewModel
    {
        private IFooService _service;
        public FooViewModel( IFooService service )
        {
            this._service = service;
            this._service.Model = this;
        }
    }
    public class FooService : IFooService
    {
        public IFooViewModel Model { get; set; }
    }
