    class Language {
      public string Code { get; set; }
      public string Name { get; set; }
    }
    void LanguageChangeHandler(sender, args) {
       // never overwrite the property       
       Languages.Clear();
       var languages = args.NewLanguages: // or whatever you do 
       foreach (var language in languages) {
         Languages.Add(language);
       }
    };
    public ObservableCollection<Language> Languages { get; } 
      = new ObservableCollection<Language>();
