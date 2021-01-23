    public class DateTimeUtcResolver : IMemberValueResolver<object, object, DateTime, DateTime>
    {
        ISessionManager sessionManager;
        public DateTimeUtcResolver(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }
        public DateTime Resolve(object source, object destination, DateTime sourceMember, DateTime destinationMember, ResolutionContext context)
        {
            //logic
        }
    }
