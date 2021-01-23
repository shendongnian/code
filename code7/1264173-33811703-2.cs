    public ObservableCollection<Filtro> Filtros { get; }
    public MainWindow_ViewModel()
    {
        Filtros = new ObservableCollection<Filtro>();
        Filtros.Add(new Filtro("tipo1", "tag1", "url1"));
        Filtros.Add(new Filtro("tipo2", "tag2", "url2"));
        Filtros.Add(new Filtro("tipo3", "tag3", "url3"));
        Filtros.Add(new Filtro("tipo4", "tag4", "url4"));
        Filtros.Add(new Filtro("tipo5", "tag5", "url5"));
    }
