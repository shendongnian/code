    var message = "Minimum Age entry is required and must range from 1 to 99 years.";
    RuleFor(s => s.ProposalDetail.AgeMin)
        .NotNull()
            .WithMessage(message)
        .GreaterThanOrEqualTo(1)
            .WithMessage(message)
         .LessThanOrEqualTo(99)
            .WithMessage(message);
