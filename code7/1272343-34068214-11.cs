    public class PersonViewModel : ViewModel
    {
        private void HandleSave()
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Age = Age
            };
            // save person using database, web service, file...
        }
        private bool CanSave()
        {
            return !ValidationErrors.Any();
        }
        public PersonViewModel()
        {
            SaveCommand = new RelayCommand(HandleSave, CanSave);
        }
        [Display(Name = "Full name of person")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        private string name;
        [Display(Name = "Age of person")]
        [Range(18, 65)]
        public int Age
        {
            get { return age; }
            set
            {
                if (age != value)
                {
                    age = value;
                    OnPropertyChanged();
                }
            }
        }
        private int age;
        public ICommand SaveCommand { get; private set; }
    }
