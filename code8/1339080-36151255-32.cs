    public abstract ViewModelBase : BindableBase
    {
        //project specific logic for all viewmodels. 
        //E.g in this project I want to use EventAggregator heavily:
        public virtual IEventAggregator () => ServiceLocator.GetInstance<IEventAggregator>()   
    }
