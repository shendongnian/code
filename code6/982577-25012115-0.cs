    public class MyViewModel : ViewModelBase
    {
        public RuleFile RuleFile { get; set; }
        [ImportingConstructor]
        public MyViewModel(RuleFile ruleFile)
        {
            RuleFile = ruleFile;
        }
    }
