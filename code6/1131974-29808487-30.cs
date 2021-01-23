    public class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand>
    {
        //notice that the need for MemberRepository is zero IMO
        private readonly IGenericRepository<Member> memberRepository;
        public CreateMemberCommandHandler(IGenericRepository<Member> memberRepository)
        {
            this.memberRepository = memberRepository;
        }
        public void Handle(CreateMemberCommand command)
        {
            var member = new Member { Name = command.MemberName };
            this.memberRepository.Insert(member);
        }
    }
    public class SaveChangesCommandHandlerDecorator<TCommand>
        : ICommandHandler<TCommand>
    {
        private ICommandHandler<TCommand> decoratee;
        private DbContext db;
        public SaveChangesCommandHandlerDecorator(
            ICommandHandler<TCommand> decoratee, DbContext db)
        {
            this.decoratee = decoratee;
            this.db = db;
        }
        public void Handle(TCommand command)
        {
            this.decoratee.Handle(command);
            this.db.SaveChanges();
        }
    }
