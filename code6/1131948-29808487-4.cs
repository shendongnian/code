    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
    public class CreateMemberCommand
    {
        public string MemberName { get; set; }
    }
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
            var member = new Member {Name = command.MemberName};
            this.memberRepository.Insert(member);
        }
    }
    public class SaveChangesCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
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
    public partial class frmMember : Form
    {
        private readonly ICommandHandler<CreateMemberCommand> commandHandler;
        public frmMember(ICommandHandler<CreateMemberCommand> commandHandler)
        {
            InitializeComponent();
            this.commandHandler = commandHandler;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.commandHandler.Handle(
                       new CreateMemberCommand { MemberName = txtName.Text });
        }
    }
