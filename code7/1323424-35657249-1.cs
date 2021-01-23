    internal class MyCollectionViewModel : BindableBase
    {
        private readonly List<ItemModel> _models = new List<ItemModel>();
        public MyCollectionViewModel()
        {
            //Add test data
            for (var i = 0; i < 5; i++)
                _models.Add( new ItemModel
                {
                    // to prove that CanExecute is actually evaluated...
                    Name = i == 3 ? "Random Text" : string.Empty,
                    Version = "Random Text",
                    Identifier = i
                } );
        }
        public IReadOnlyCollection<ItemViewModel> TheCollection => _models.Select( x => new ItemViewModel( x ) ).ToList();
    }
    internal class ItemViewModel : BindableBase
    {
        public ItemViewModel( ItemModel item )
        {
            _item = item;
            VerifyCommand = new DelegateCommand( () =>
                                                 {
                                                     /* Do something */
                                                 }, () => !string.IsNullOrWhiteSpace( Version ) && !string.IsNullOrWhiteSpace( Name ) );
        }
        public string Name => _item.Name;
        public string Version => _item.Version;
        public int Identifier => _item.Identifier;
        public DelegateCommand VerifyCommand
        {
            get;
        }
        private readonly ItemModel _item;
    }
