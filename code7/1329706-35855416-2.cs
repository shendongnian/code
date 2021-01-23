	public class UserViewModel
	{
		private User Model;
		public UserViewModel(User model)
		{
			this.Model = model;
		}
		public int ID
		{
			get { return this.Model.ID; }
			set { this.Model.ID = value; RaisePropertyChanged(); }
		}
		public string FirstName
		{
			get { return this.Model.FirstName; }
			set { this.Model.FirstName = value; RaisePropertyChanged(); }
		}
		// etc
	}
