    public static PersonViewModelFactory
    {
        public static TViewModel CreateFrom<TViewModel>(TEntity entity)
            where TViewModel : PersonViewModel, new()
        {
            return new TViewModel { // map properties from Person }
        }
    }
