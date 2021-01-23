    // These all should be named something relevant to your domain
    public interface IHandler
    {
        void Handle(string request);
    }
    public class Handler
    {
        protected IHandler successor;
        protected Handler(IHandler successor)
        {
            this.successor = successor;
        }
        protected virtual void Successor(string request)
        {
            successor?.Handle(request);
        }
    }
    public class Registration : Handler, IHandler
    {
        public Registration(IHandler successor) 
            : base(successor) { }
        public void Handle(string request)
        {
            Console.WriteLine($"Registration handled request {request}");
            base.Successor(request);
        }
    }
    public class Enrollment : Handler, IHandler
    {
        public Enrollment(IHandler successor) 
            : base(successor) { }
        public void Handle(string request)
        {
            Console.WriteLine($"Enrollment handled request {request}");
            base.Successor(request);
        }
    }
    public class Assessment : Handler, IHandler
    {
        public Assessment(IHandler successor) 
            : base(successor) { }
        public void Handle(string request)
        {
            if (request.Equals("Bob", StringComparison.InvariantCulture))
            {
                Console.WriteLine("Bob failed assessment.");
                return;
            }
            Console.WriteLine($"Assessment handled request {request}");
            base.Successor(request);
        }
    }
