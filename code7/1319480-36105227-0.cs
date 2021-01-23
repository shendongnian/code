    public enum Gender
    {
        Male,
        Female
    };
    // this should be a simple class (POCO), persistence agnostic
    public class PersonDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
    // repository interface
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
    }
    // this is responsible for delivering person related information without exposing fetching details
    public class PersonService
    {
        private IRepository<PersonDTO> _Repository;
        public PersonService(IRepository<PersonDTO> repository)
        {
            _Repository = repository;
        }
        // normally, service should return service models that are view agnostic, but this requires extra mapping
        // so, for convenience service returns the view model
        public PersonEditorModel GetPerson(int id)
        {
            var ret = AutoMapper.Mapper.Map<PersonEditorModel>(_Repository.GetById(id));
            return ret;
        }
    }
    // base editor model (or view model)
    public class BaseEditorModel : INotifyPropertyChanged
    {
        /// <summary>
        ///  Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        protected void OnPropertyChanged(string propertyName)
        {
            var ev = PropertyChanged;
            if (ev != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    // base editor model (or view model) that allow statically-typed property changed notifications
    public abstract class BaseEditorModel<TVm> : BaseEditorModel
                                  where TVm : BaseEditorModel<TVm>
    {
        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        /// <param name="expr">Lambda expression that identifies the updated property</param>
        protected void OnPropertyChanged<TProp>(Expression<Func<TVm, TProp>> expr)
        {
            var prop = (MemberExpression)expr.Body;
            OnPropertyChanged(prop.Member.Name);
        }
    }
    // the actual editor
    // notice that property changed is done directly on setters and without magic strings
    public class PersonEditorModel : BaseEditorModel<PersonEditorModel>
    {
        public BindingList<string> Titles { get; private set; }
        public PersonEditorModel()
        {
            _repository = repository;
            Titles = new BindingList<string>();
            UpdateTitles();
        }
        private Gender _Gender;
        public Gender Gender
        {
            get { return _Gender; }
            set
            {
                _Gender = value;
                UpdateTitles();
                OnPropertyChanged(m => m.Gender);
            }
        }
        private void UpdateTitles()
        {
            Titles = Gender == Gender.Female ?
                new BindingList<string>(new[] { "Ms", "Mrs" }) :
                new BindingList<string>(new[] { "Mr", "Sir" });
            OnPropertyChanged(m => m.Titles);
        }
    }
    // just an example
    class Program
    {
        static void Main(string[] args)
        {
            // this should be performed one per application run
            // obsolete in a newer version
            AutoMapper.Mapper.CreateMap<PersonDTO, PersonEditorModel>();
            var service = new PersonService(null);     // get service using DI
            // work on a dummy/mock person
            var somePerson = service.GetPerson(30);
            // bind and do stuff with person view model
        }
    }
