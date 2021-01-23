    public class ComboboxDataContext:BaseObservableObject
    {
        private ObservableCollection<ComboModel> _cdTypes;
        private ComboModel _assignment;
        private string _assignmentText;
        private string _lastAcceptedName;
        public ComboboxDataContext()
        {
            CDTypes = new ObservableCollection<ComboModel>
            {
                new ComboModel
                {
                    CDType = new ComboModelSubModel
                    {
                        Name = "Cd-1",
                        ID = "1",
                    },
                },
                new ComboModel
                {
                    CDType = new ComboModelSubModel
                    {
                        Name = "Cd-2",
                        ID = "2",
                    }
                },
                new ComboModel
                {
                    CDType = new ComboModelSubModel
                    {
                        Name = "Cd-3",
                        ID = "3",
                    },
                },
                new ComboModel
                {
                    CDType = new ComboModelSubModel
                    {
                        Name = "Cd-4",
                        ID = "4",
                    }
                }
            };
            Assignment = CDTypes.FirstOrDefault();
        }
        public ObservableCollection<ComboModel> CDTypes
        {
            get { return _cdTypes; }
            set
            {
                _cdTypes = value;
                OnPropertyChanged();
            }
        }
        public ComboModel Assignment
        {
            get { return _assignment; }
            set
            {
                if (value == null)
                    _lastAcceptedName = _assignment.CDType.Name;
                _assignment = value;
                OnPropertyChanged();
            }
        }
        //on lost focus when edit is done will check and update the last edited value
        public string AssignmentText
        {
            get { return _assignmentText; }
            set
            {
                _assignmentText = value;
                OnPropertyChanged();
                UpDateSourceCollection(AssignmentText);
            }
        }
        //will do the the update on combo lost focus to prevent the 
        //annessasary updates (each property change will make a lot of noice in combo)
        private void UpDateSourceCollection(string assignmentText)
        {
            var existingModel = CDTypes.FirstOrDefault(model => model.CDType.Name == assignmentText);
            if (existingModel != null) return;
            if (_lastAcceptedName == null)
            {
                CDTypes.Add(new ComboModel{CDType = new ComboModelSubModel{ID = string.Empty, Name = assignmentText}});
            }
            else
            {
                var existingModelToEdit = CDTypes.FirstOrDefault(model => model.CDType.Name == _lastAcceptedName);
                if(existingModelToEdit == null) return;
                existingModelToEdit.CDType.Name = assignmentText;
                existingModelToEdit.CDType.ID = string.Empty;
            }
        }
    }
    public class ComboModel:BaseObservableObject
    {
        private ComboModelSubModel _cdType;
        public ComboModelSubModel CDType
        {
            get { return _cdType; }
            set
            {
                _cdType = value;
                OnPropertyChanged();
            }
        }
    }
    public class ComboModelSubModel:BaseObservableObject
    {
        private string _id;
        private string _name;
        public string ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }
