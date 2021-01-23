    public class PersonEditorModel : PersonDTO {
    
      public BindingList<string> Titles { get; private set; }
    
      private readonly IRepository _repository;
      public PersonEditorModel(IRepository repository) {
        _repository = repository;
        Titles = new BindingList<string>();
    
        UpdateTitles();
        PropertyChanged += OnPropertyChanged;
      }
    
      private void OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
        if (e.PropertyName == "Gender") {
           UpdateTitles();
        }
      }
    
      private void UpdateTitles() {
        Titles.Clear();
        if (Gender == Gender.Female) {
          Titles.AddRange(new[] {"Ms", "Mrs"});
        else
          Titles.AddRange(new[] {"Mr", "Sir"});
      }
    }
