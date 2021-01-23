    public class TabCategoryViewModel : ViewModelBase
    {
        public readonly IMessanger messageService;
        public TabCategoryViewModel(IMessanger messageService) 
        {
            if(messageService == null) 
            {
                 throw ArgumentNullException("messageService");
            }
            this.messageService = messageService;
            this.messageService.Register<GoToPageMessage>(this, OnSelectedViewChanged);
        }
        protected void OnSelectedViewChanged(SelectedViewMessage message) 
        {
             this.IsVisible = message.ViewName == "UserControl2";
        }
        private bool isVisible;
        public bool IsVisible 
        {
            get { return isVisible; }
            set 
            {
                if(isVisible != value) 
                {
                    isVisible = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
