    class ReactiveModel
    {
        public string ValueA {get;set;}
        private readonly Subject<string> valueB = new Subject<string>();
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
        private readonly ReactiveProperty<string> valueA;
        private readonly ReactiveProperty<string> valueB;
        public ReactiveViewModel(ReactiveModel model)
        {
            this.model = model;
    
            valueA = new ReactiveProperty<string>(model.ValueA);
            valueA.Subscribe(x => model.ValueA = x);
            valueB = model.ValueB.ToReactiveProperty();
            valueB.Subscribe(model.UpdateB);
        }
        public IObservable<string> ValueA
        {
            get
            {
                return valueA;
            }
        }
        public ReactiveProperty<string> ValueB
        {
            get 
            {
                return valueB;
            }
        }
    }
