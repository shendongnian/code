<!-- -->
    public class MainViewModel : INotifyPropertyChanged
	{
        // this holds the data
		private Dictionary<string, List<string>> departmentUsers = new Dictionary<string,List<string>>();
		private List<string> departments;
		public List<string> Departments
		{
			get { return departments; }
			set
			{
				if (value != departments)
				{
					departments = value;
					OnNotifyPropertyChanged("Departments");
				}
			}
		}
		private string selectedDepartment;
		public string SelectedDepartment
		{
			get { return selectedDepartment; }
			set
			{
				if (value != selectedDepartment)
				{
					selectedDepartment = value;
					OnNotifyPropertyChanged("SelectedDepartment");
					// update users list
					Users = departmentUsers[selectedDepartment];
				}
			}
		}
		private List<string> users;
		public List<string> Users
		{
			get { return users; }
			set
			{
				if (value != users)
				{
					users = value;
					OnNotifyPropertyChanged("Users");
				}
			}
		}
		public MainViewModel()
		{
            // sample data
			departmentUsers = new Dictionary<string, List<string>>();
			departmentUsers.Add("Department 1", new List<string>() { "1.1", "1.2", "1.3" });
			departmentUsers.Add("Department 2", new List<string>() { "2.1", "2.2", "2.3", "2.4", "2.5" });
			departmentUsers.Add("Department 3", new List<string>() { "3.1", "3.2" });
			departmentUsers.Add("Department 4", new List<string>() { "4.1", "4.2", "4.3" });
            // initial state
			Departments = new List<string>(departmentUsers.Keys);
			SelectedDepartment = Departments[0];
		}
        // simple INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnNotifyPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
