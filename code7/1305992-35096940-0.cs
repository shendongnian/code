    public ObservableCollection<Tuple<String, String>> MyObservableCollection;
    public CollectionViewSource MyCollectionViewSource { get; set; }
    public PetViewModel()
    {
        this.MyObservableCollection = new ObservableCollection<Tuple<String, String>>();
        this.MyCollectionViewSource = new CollectionViewSource();
        this.MyCollectionViewSource.Source = this.MyObservableCollection;
        this.MyCollectionViewSource.Filter += OnlyCatsFilter;
        this.MyObservableCollection.Add(new Tuple<string,string>("Paul", "Cat"));
        this.MyObservableCollection.Add(new Tuple<string,string>("Zoey", "Dog"));
        this.MyObservableCollection.Add(new Tuple<string,string>("Dude", "Turtle"));
        this.MyCollectionViewSource.View.Refresh();
    }
    public void OnlyCatsFilter(object sender, FilterEventArgs e)
    {
        if (e.Item != null)
        {
            e.Accepted = (e.Item as Tuple<String, String>).Item2 == "Cat";
        }
    }
