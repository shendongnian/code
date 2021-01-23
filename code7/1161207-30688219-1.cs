    class MyViewModel : INotifyPropertyChanged
    {
        // The compiler will complain about this:
        // Warning 3 The event 'MyNamespace.MyViewModel.PropertyChanged' is never used
        public event PropertyChangedEventHandler PropertyChanged;
        private string _myProp;
        public string MyProp
        {
            get { return _myProp; }
            set
            {
                _myProp = value;
                this.RaisePropertyChanged();
            }
        }
        public readonly int MyImmutableValue;
    }
    // ...
 
    var vm = new MyViewModel();
    vm.PropertyChanged += (sender, evt) => Console.WriteLine("Prop changed {0}", evt.PropertyName);
    vm.MyProp = "abc";
    vm.RaisePropertyChanged(x => x.MyProp);
    vm.RaisePropertyChanged("MyProp");
    vm.RaisePropertyChanged("Un Oh. Do we have a problem");
    vm.RaisePropertyChanged(x => x.MyImmutableValue);
    vm.RaisePropertyChanged("MyImmutableValue");
    
