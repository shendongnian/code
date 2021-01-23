    public sealed class DogLoaderVM : INotifyPropertyChanged
    {
        public DogVM Dog { /* stuff here */ }
        public bool IsLoading { /* stuff here */ }
        // other stuff here
    }
    public sealed class DogVM : INotifyPropertyChanged
    {
        public string Name { /* stuff here */ }
        public string Breed { /* stuff here */ }
        public string Coat { /* stuff here */ }
        public DateTime BornOn { /* stuff here */ }
        // other stuff here
    }
