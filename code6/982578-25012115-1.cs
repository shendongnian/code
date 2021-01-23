    public class MyViewModel : ViewModelBase, IPartImportsSatisfiedNotification
    {
        [Import]
        public RuleFile RuleFile { get; set; }
        public void OnImportsSatisfied()
        {
            // Signifies that Imports have been resolved  
        }
    }
