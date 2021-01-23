    public class ThreadScopedMemberServiceDecorator : IMemberService
    {
        private readonly Func<IMemberService> decorateeFactory;
        private readonly Container container;
        public ThreadScopedMemberServiceDecorator(Func<IMemberService> decorateeFactory,
            Container container)
        {
            this.decorateeFactory = decorateeFactory;
            this.container = container;
        }
        public void Save(List<Member> members)
        {
            using (ThreadScopedLifestyle.BeginScope(container)) 
            {
                IMemberService service = this.decorateeFactory.Invoke();
                service.Save(members);
            }
        }
    }
