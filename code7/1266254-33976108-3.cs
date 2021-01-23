    class ReactiveViewModel
    {
        private readonly ReactiveProperty<string> valueA;
        private readonly ReactiveModel model;
        public ReactiveViewModel(ReactiveModel model)
        {
            this.model = model;
    
            valueA = new ReactiveProperty<string>(model.ValueA);
            valueA.Subscribe(x => model.ValueA = x);
        }
        public IObservable<string> ValueA
        {
            get
            {
                return valueA;
            }
        }
    }
