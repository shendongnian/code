    public class SourceViewModel
    {
        public string SourceText { ... }
        // Publish SendString event on SourceText changes...
    }
    
    public class DestinationViewModel
    {
        private IEventAggregator _aggregator;
        // Bind DestinationText to your destination text box...
        public string DestinationText { .. }
    
        public DestinationViewModel(IEventAggregator eventAggregator)
        {
            ...
          _aggregator.GetEvent<SendStringEvent>().Subscribe(StringAction2,
            ThreadOption.UIThread, false, i => DestinationText = i.Text);
        }    
    }
