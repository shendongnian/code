    public class Model
    {
        public string Property {get; set;}
    }
    public class ViewModel
    {
        public string Binding BindProperty
        {
            get { return modelInstance.Property; }
            set
            {
                modelInstance.Property = value;
                OnPropertyChanged();
            }
        }
    }
