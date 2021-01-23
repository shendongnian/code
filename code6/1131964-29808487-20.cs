    public class LifetimeScopedMemberServiceDecorator : IMemberService
    {
        private readonly Func<IMemberService> decorateeFactory;
        private readonly Container container;
        public LifetimeScopedMemberServiceDecorator(Func<IMemberService> decorateeFactory,
            Container container)
        {
            this.decorateeFactory = decorateeFactory;
            this.container = container;
        }
        public void Save(List<Member> members)
        {
            using (this.container.BeginLifetimeScope())
            {
                IMemberService service = this.decorateeFactory.Invoke();
                service.Save(members);
            }
        }
    }
