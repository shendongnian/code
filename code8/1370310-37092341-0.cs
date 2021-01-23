	public class FacultyMemberViewModelValidator : AbstractValidator<FacultyMemberViewModel> {
		public FacultyMemberViewModelValidator() {
			RuleFor(f => f.Name)
				.NotEmpty().WithMessage("You must specify a name.")
				.Length(0, 64).WithMessage("The name cannot exceed 64 characters in length.");
			RuleFor(s => s.SelectedDepartments)
				.NotEmpty().WithMessage("You must specify at least one department.")
		}
	}
	[Validator(typeof(FacultyMemberViewModelValidator))]
	public class FacultyMemberViewModel {
		public int Id { get; set; }
		public string Name { get; set; }
		public int[] SelectedDepartments { get; set; }
		[DisplayName("Departments")]
		public IEnumerable<SelectListItem> DepartmentList { get; set; }
	}
