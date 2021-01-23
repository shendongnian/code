    class ReactiveModel
    {
        public string ValueA {get;set;}
        private ISubject<string> valueB = new Subject<string>();
        public IObservable<string> ValueB
        {
            get
            {
                return valueB;
            }
        }
        public void UpdateB(string newValue)
        {
            valueB.OnNext(newValue);
        }
    }
    class ReactiveViewModel
    {
        private readonly ReactiveModel model;
        private readonly ReactiveProperty<string> valueB;
        public ReactiveViewModel(ReactiveModel model)
        {
            this.model = model;
    
            valueB = model.ValueB.ToReactiveProperty();
            valueB.Subscribe(model.UpdateB);
        }
        public ReactiveProperty<string> ValueB
        {
            get 
            {
                return valueB;
            }
        }
    }
