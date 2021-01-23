    public class MyViewModel : ReactiveObject
        {
            private readonly ObservableAsPropertyHelper<bool> _isValidPropertyHelper;
    
            public MyViewModel()
            {
                var listChanged = Children.Changed.Select(_ => Unit.Default);
                var childrenChanged = Children.ItemChanged.Select(_ => Unit.Default);
                _isValidPropertyHelper = listChanged.Merge(childrenChanged)
                                                    .Select(_ => Children.All(c => c.IsValid))
                                                    .ToProperty(this, model => model.IsValid);
    
            }
            public bool IsValid
            {
                get { return _isValidPropertyHelper.Value; }
            }
    
            public ReactiveList<Item> Children { get; set; }
        }
