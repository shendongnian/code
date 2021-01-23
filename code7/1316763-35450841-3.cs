    public class MainViewModel:BaseObservableObject
    {
        private DepartmentModel _selectedDepartment;
        private OfficeModel _selectedOffice;
        public MainViewModel()
        {
            Dal = new DataLayer();
            Users = new ObservableCollection<UserModel>();
            Departments = new ObservableCollection<DepartmentModel>(Dal.GetAllDepartments());
            InitUsersCollection();
        }
        private void InitUsersCollection()
        {
            if(Departments == null) return;
            Departments.ToList().ForEach(model =>
            {
                model.Offices.ToList().ForEach(officeModel =>
                {
                    if (officeModel.Users == null) return;
                    officeModel.Users.ToList().ForEach(userModel => Users.Add(userModel));
                });
            });
        }
        public ObservableCollection<UserModel> Users { get; set; }
        public ObservableCollection<DepartmentModel> Departments { get; set; }
        private DataLayer Dal { get; set; }
    }
    public class DataLayer
    {
        public List<DepartmentModel> GetAllDepartments()
        {
            //pull and map your collection sources using your DB service
            //For example:
            return new List<DepartmentModel>
            {
                new DepartmentModel
                {
                    DepartmentId = 1,
                    DepartmentName = "A",
                    Offices = new ObservableCollection<OfficeModel>
                    {
                        new OfficeModel
                        {
                            DepartmentId = 1,
                            OfficeName = "AA",
                            Users = new ObservableCollection<UserModel>(new List<UserModel>
                            {
                                new UserModel {Name = "Avicenna", LastName = "Abu Ali Abdulloh Ibn-Sino"},
                                new UserModel {Name = "Omar", LastName = "Khayyam"},
                                new UserModel {Name = "RAMBAM", LastName = "Moshe ben Maimon"}
                            })
                        },
                        new OfficeModel 
                        {
                            
                            DepartmentId = 1, 
                            OfficeName = "AB", 
                            Users = new ObservableCollection<UserModel>(new List<UserModel>
                            {
                                new UserModel {Name = "Leo", LastName = "Tolstoi"},
                                new UserModel {Name = "Anton", LastName = "Chekhov"},
                            })},
                    }
                },
                new DepartmentModel
                {
                    DepartmentId = 2,
                    DepartmentName = "B",
                    Offices = new ObservableCollection<OfficeModel>
                    {
                        new OfficeModel
                        {
                            DepartmentId = 2, OfficeName = "BA",
                            Users = new ObservableCollection<UserModel>(new List<UserModel>
                            {
                                new UserModel {Name = "B", LastName = "O"},
                                new UserModel {Name = "B", LastName = "N"},
                            }),
                        },
                        new OfficeModel
                        {
                            DepartmentId = 2, OfficeName = "BB",
                            Users = new ObservableCollection<UserModel>(new List<UserModel>
                            {
                                new UserModel {Name = "John", LastName = "Walker"},
                                new UserModel {Name = "Gregory", LastName = "Rasputin"},
                            }),
                        },
                    }
                },
                new DepartmentModel
                {
                    DepartmentId = 3,
                    DepartmentName = "C",
                    Offices = new ObservableCollection<OfficeModel>
                    {
                        new OfficeModel {DepartmentId = 3, OfficeName = "CA"},
                        new OfficeModel {DepartmentId = 3, OfficeName = "CB"},
                        new OfficeModel {DepartmentId = 3, OfficeName = "CC"}
                    }
                }
            };
        }
    }
    public class OfficeModel:BaseObservableObject
    {
        private int _departmentModel;
        private string _officeName;
        private DepartmentModel _department;
        private ObservableCollection<UserModel> _users;
        public int DepartmentId
        {
            get { return _departmentModel; }
            set
            {
                _departmentModel = value;
                OnPropertyChanged();
            }
        }
        public DepartmentModel Department
        {
            get { return _department; }
            set
            {
                _department = value;
                OnPropertyChanged();
            }
        }
        public string OfficeName
        {
            get { return _officeName; }
            set
            {
                _officeName = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<UserModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(()=>Users);
            }
        }
    }
    public class DepartmentModel:BaseObservableObject
    {
        private string _departmentName;
        public string DepartmentName
        {
            get { return _departmentName; }
            set
            {
                _departmentName = value;
                OnPropertyChanged();
            }
        }
        public int DepartmentId { get; set; }
        public ObservableCollection<OfficeModel> Offices { get; set; }
    }
    public class UserModel:BaseObservableObject
    {
        private string _name;
        private string _lastName;
        private DepartmentModel _department;
        private OfficeModel _office;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public DepartmentModel Department
        {
            get { return _department; }
            set
            {
                _department = value;
                OnPropertyChanged();
                OnPropertyChanged(()=>OfficesCollection);
            }
        }
        public ObservableCollection<OfficeModel> OfficesCollection
        {
            get { return Department.Offices; }
        }
        public OfficeModel Office
        {
            get { return _office; }
            set
            {
                _office = value;
                OnPropertyChanged();
            }
        }
    }
