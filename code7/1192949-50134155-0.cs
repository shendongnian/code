    RuleFor(t => t.DocumentName)
                .NotEmpty()
                .WithMessage("message")
                .DependentRules(() =>
                    {
                        RuleFor(d2 => d2.DocumentName).MaximumLength(200)
                            .WithMessage(string.Format(stringLocalizer[""message""], 200));
                    });
