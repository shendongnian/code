    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
    public class CreateMemberCommand
    {
        public string MemberName { get; set; }
    }
