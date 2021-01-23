    public interface IUniqueEmailCommand : IValidatorCommand { }
    public interface IEmailFormatCommand : IValidatorCommand { }
    public class UniqueEmail : IUniqueEmailCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        public UniqueEmail(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public object Input { get; set; }
        public CustomValidationResult Execute()
        {
            // Access Repository from Unit Of work here and perform your validation based on Input
            return new CustomValidationResult { IsValid = false, ErrorMessage = "Email not unique" };
        }
    }
    public class EmailFormat : IEmailFormatCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmailFormat(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public object Input { get; set; }
        public CustomValidationResult Execute()
        {
            // Access Repository from Unit Of work here and perform your validation based on Input
            return new CustomValidationResult { IsValid = false, ErrorMessage = "Email format not matched" };
        }
    }
