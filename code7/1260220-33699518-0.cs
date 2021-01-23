    RuleFor(x => x.Password)
        .NotEmpty()
             .WithMessage("Password in required")
        .Length(6, 100)
            .WithMessage("Password not long enough")
        .Must(Trial)
            .WithMessage("Password must triggered");
    private bool Trial(RegisterViewModel viewModel, string value) {
        if (string.IsNullOrEmpty(value)) {
            return false;
        } else {
            return true;
        }
    }
