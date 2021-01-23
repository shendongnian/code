    class ReactiveModel
    {
        public string ValueA {get;set;}
        private ISubject<string> valueB = new Subject<string>();
        public Observable<string> ValueB
        {
            get
            {
                return valueB;
            }
        }
        public string UpdateB(string newValue)
        {
            valueB.OnNext(newValue);
        }
    }
    class ReactiveViewModel : INotifyPropertyChanged
    {
        private readonly ReactiveModel model;
        private readonly ReactiveProperty<string> valueB;
        public ReactiveViewModel(ReactiveModel model)
        {
            this.model = model;
    
            valueB = model.valueB.ToReactiveProperty();
            valueB.Subscribe(model.UpdateB);
        }
        public Reactive<string> ValueB
        {
            get 
            {
                return valueB;
            }
        }
    }
 
