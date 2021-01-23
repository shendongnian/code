    public class MyViewModel : NotificationObject
    {
    
        private readonly CompositeCommand saveAllCommand;
    
        public ArticleViewModel(INewsFeedService newsFeedService,
                                IRegionManager regionManager,
                                IEventAggregator eventAggregator)
        {
            this.saveAllCommand = new CompositeCommand();
            this.saveAllCommand.RegisterCommand(new SaveProductsCommand());
            this.saveAllCommand.RegisterCommand(new SaveOrdersCommand());
        }
    
        public ICommand SaveAllCommand
        {
            get { return this.saveAllCommand; }
        }
    }
