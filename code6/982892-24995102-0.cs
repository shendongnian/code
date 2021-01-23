    public class CompositeRequest<TFor> : IRequest
    {
        public CompositeRequest(params TFor[] requests)
        {
            this.Requests = requests;
        }
        public TFor[] Requests { get; private set; }
    }
    public interface ICompositeHandler<TFor> : IHandler<CompositeRequest<TFor>> { }
    public class CompositeHandler<TFor> : ICompositeHandler<TFor>
        where TFor : IRequest
    {
        private readonly IHandler<TFor> handler;
        public CompositeHandler(IHandler<TFor> handler)
        {
            this.handler = handler;
        }
        public void Handle(CompositeRequest<TFor> request)
        {
            foreach (var r in request.Requests)
            {
                this.handler.Handle(r);
            }
        }
    }
