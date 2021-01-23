    using System.Collections.ObjectModel;
    private ObservableCollection<DiagramObject> _objects;
    public ObservableCollection<DiagramObject> Objects
    {
        get { return _nodes ?? (_nodes = new ObservableCollection<Node>()); }
    }
    public MainClass
    {
        _objects = new ObservableCollection<DiagramObject>(constructor that makes the objects);
    }
