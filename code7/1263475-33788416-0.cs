    public sealed class DogVM : INotifyPropertyChanged // because bindings, yeah?
    {
        public string Name { /* stuff here */ }
        public string Breed { /* stuff here */ }
        public string Coat { /* stuff here */ }
        public DateTime BornOn { /* stuff here */ }
        public bool IsLoading { /* stuff here */ }
        // other stuff as well, like INotifyPropertyChanged implementation
    }
