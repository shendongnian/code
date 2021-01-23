    class MasterViewModel : BindableBase
    {
        public IEnumerable<BindableBase> Items
        {
            get { return new[] { new ViewModel1(), new ViewModel2() }
        }
    }
