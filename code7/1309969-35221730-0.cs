	public class UsersViewModel : INotifyPropertyChanged
	{
		public UsersViewModel() 
		{
			UserDatas = new ObservableCollection<User>();
			AddNewUserCommand = new RelayCommand(AddNewUser, param => !this.IsNewUser);
			SaveUserCommand = new RelayCommand(SaveUser);
			CancelNewUserCommand = new RelayCommand(CancelNewUser, param => this.IsNewUser);
		}
	
		private ObservableCollection<User> userDatas;
		public ObservableCollection<User> UserDatas
		{
			get { return userDatas; }
			set
			{
				userDatas = value;
				RaisePropertyChanged("UserDatas");
			}
		}
		
		private User selectedUser;
		public User SelectedUser 
		{
			get { return selectedUser; }
			set
			{
				selectedUser = value;
				RaisePropertyChanged("SelectedUser");
				RaisePropertyChanged("IsNewUser");
			}
		}
		
		public bool IsNewUser 
		{
			get 
			{
				if(SelectedUser==null)
					return false;
					
				return SelectedUser.UserId == 0;
			}
		}
		
		public ICommand AddNewUserCommand { get; private set; }
		public ICommand CancelNewUserCommand { get; private set; }
		public ICommand SaveUserCommand { get; private set; }
		
		private void AddNewUser() 
		{
			SelectedUser = new User();
		}
		
		private void SaveUser() 
		{
			// Just in case of concurency
			var newUser = SelectedUser;
			if(newUser == null) 
			{
				return;
			}
			var isNewUser = newUser.UserId == 0;
			// Persist it to the database
			this.userRepository.Add(newUser);
			this.userRepository.SaveChanges();
			
			// If all worked well, add it to the observable collection
			if(isNewUser) 
			{
				// Only add if new, otherwise it should be already in the collection
				UserDatas.Add(newUser)
			}
		}
	}
