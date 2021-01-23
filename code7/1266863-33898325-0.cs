    public class MyViewModel()
    {
        ObservableCollection<Person> People { get; set; }
        Person SelectedPerson { get; set; }
        string NewPersonName { get; set; }
        ICommand UpdatePersonName { get; }
    }
