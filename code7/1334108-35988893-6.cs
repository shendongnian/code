    public class Person
    {
        public string Description { get; set; }
        public ObservableCollection<Person> Children { get; set; } = new ObservableCollection<Person>();
    }
