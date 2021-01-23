    //GridView VM - screen is a simple implementation of the INPC
    public class StackOptimizerChannelRulesViewModel : Screen
    {
        //provides values for grid view items source collection
        private readonly IStackOptimizerStep _step;
        //IUserInteractionService  is a simple implementation of the massage box service
        private readonly IUserInteractionService _interactionService;
        private bool _imBusy;
        public StackOptimizerChannelRulesViewModel(IStackOptimizerStep step, IUserInteractionService interactionService)
        {
            _step = step;
            _interactionService = interactionService;
            DisplayName = "Channels Rules";
            ChannelRuleMappings = new ObservableCollection<ChannelRuleMappingModelBase>();
        }
        protected override void OnInitialize()
        {
            base.OnInitialize();
            Init();
        }
        public ObservableCollection<ChannelRuleMappingModelBase> ChannelRuleMappings { get; set; }
        //allows to show the vbusy indicator
        public bool ImBusy
        {
            get { return _imBusy; }
            set
            {
                _imBusy = value;
                NotifyOfPropertyChange(()=>ImBusy);
            }
        }
        private ICommand _cmd;
        public ICommand BuidValueChangedCommand
        {
            get { return _cmd ?? (_cmd = new ActionCommand(BuildValueChanged)); }
        }
        private void BuildValueChanged()
        {
            ImBusy = true;
            // Ask confirmation for delete.
            if (_interactionService.AskYesNo("This will be removed from the collection"))
            {
                //Add yor logic on yes
                ImBusy = false;
            }
            else
            {
                //Add yor logic on no
                ImBusy = false;
            }
        }
        private void Init()
        {
            var channelRuleMappings = _step.GetRulesForChannels();
            if (channelRuleMappings != null)
                channelRuleMappings.ForEach(parameter => ChannelRuleMappings.Add(new ChannelRuleMappingModel(parameter, _interactionService)));
        }
    }
    //Row VM base 
    public class ChannelRuleMappingModelBase : PropertyChangedBase
    {
        private string _name;
        private readonly IUserInteractionService _interactionService;
        private StackOptimizerSelectionRules _stackOptimizerSelectedRule;
        private object _build;
        public ChannelRuleMappingModelBase(string channelName, IUserInteractionService interactionService)
        {
            _name = channelName;
            _interactionService = interactionService;
        }
        public virtual string Name
        {
            get { return _name; }
        }
        public virtual StackOptimizerSelectionRules StackOptimizerSelectedRule
        {
            get { return _stackOptimizerSelectedRule; }
            set
            {
                _stackOptimizerSelectedRule = value;
                NotifyOfPropertyChange(() => StackOptimizerSelectedRule);
            }
        }
        public object Build
        {
            get { return _build; }
            set
            {
                _build = value;
                NotifyOfPropertyChange(() => Build);
            }
        }
    }
    //Row VM
    public class ChannelRuleMappingModel : ChannelRuleMappingModelBase
    {
        private StackOptimizerSelectionRules _stackOptimizerSelectedRule;
        private ISpectrumRuleParameter _ruleMapping;
        public ChannelRuleMappingModel(ISpectrumRuleParameter ruleMapping, IUserInteractionService interactionService):
            base(ruleMapping.PolarizationKey.Name, interactionService)
        {
            _ruleMapping = ruleMapping;
            _stackOptimizerSelectedRule = _ruleMapping.Rule;
        }
        public override StackOptimizerSelectionRules StackOptimizerSelectedRule
        {
            get { return _stackOptimizerSelectedRule; }
            set
            {
                _stackOptimizerSelectedRule = value;
                NotifyOfPropertyChange(() => StackOptimizerSelectedRule);
                UpdateOriginalRuleMapping(StackOptimizerSelectedRule);
            }
        }
        private void UpdateOriginalRuleMapping(StackOptimizerSelectionRules stackOptimizerSelectedRule)
        {
            if(_ruleMapping == null) return;
            _ruleMapping.Rule = stackOptimizerSelectedRule;
        }
    }
