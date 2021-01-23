    public class BaseValidator<T> : AbstractValidator<T>
    {
        public void RuleForText(Expression<Func<T, string>> expression, string msg)
        {
            RuleFor(expression).NotEmpty().WithMessage(msg);
            RuleFor(expression).Length(1, 100).WithMessage(msg);
            RuleFor(expression).Matches("[A-Z]*").WithMessage(msg);
        }
        public void RuleForEmail(Expression<Func<T, string>> expression, string msg)
        {
            RuleFor(expression).NotEmpty().WithMessage(msg);
            RuleFor(expression).EmailAddress().WithMessage(msg);
        }
    }
    public class MemberValidator : BaseValidator<Member>
    {
        public MemberValidator()
        {
            RuleForText(member => member.Name, "My Message");
            RuleForEmail(member => member.Email, "My Message");
        }
    }
    public class Member
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
