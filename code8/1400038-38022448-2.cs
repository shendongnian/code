    public class StudentsViewModel : ViewModelBase
    {
        private ObservableCollection<StudentViewModel> _studentList;
        private StudentViewModel _selectedStudent;
        public StudentsViewModel()
        {
            StudentList = new ObservableCollection<StudentViewModel>();
            StudentList.Add(new StudentViewModel { Name = "Joe", Age = 21 });
            StudentList.Add(new StudentViewModel { Name = "Jane", Age = 19 });
        }
        public ObservableCollection<StudentViewModel> StudentList
        {
            get { return _studentList; }
            private set { _studentList = value; }
        }
        public StudentViewModel SelectedStudent
        {
            get { return _selectedStudent; } 
            set { Set<StudentViewModel>(ref _selectedStudent, value); }
        }
    }
