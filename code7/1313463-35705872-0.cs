    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator(DbContext dbContext) {
            RuleFor(x => x.Id)
                .MustFindProjectById(dbContext);
        }
    }
    
