    public class ViewModel
    {
        public ObservableCollection<PersonViewModel> Persons { get; private set; }
        public ViewModel()
        {
            Persons = new ObservableCollection<PersonViewModel>();
            Persons.AddRange(PersonsGateway.RetrievePersons().ToList());
        }
    }
