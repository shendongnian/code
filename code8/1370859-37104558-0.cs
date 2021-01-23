    public class Mediator
    {
        // These fields should be set via Constructor Injection
        private readonly MainWindowViewModel mainWindowViewModel;
        private readonly Dictionary<ViewModelId, IViewFactory> viewFactories;        
        public void NotifyColleagues(ViewModelId targetViewModelId, ViewModelArguments arguments)
        {
            var targetFactory = this.viewModelFactories[targetViewModelId];
            var view = targetFactory.Create(viewModelArguments);
            this.mainWindowViewModel.PagesControl = view;
        }
        // other members omitted to keep the example small
    }
