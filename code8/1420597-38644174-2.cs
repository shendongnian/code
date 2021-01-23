    public Ingredients()
    {
        this.InitializeComponent();
        this.DataContext = this;
        IngredientsCollection = new ObservableCollection<Ingredient>()
        TestViewBinding();
    };
