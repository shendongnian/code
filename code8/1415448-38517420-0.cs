    public ObservableCollection<Ingredient> IngredientsCollection = new ObservableCollection<Ingredient>();
    
    private void TestListViewBinding()
    {
        var db = new SQLiteConnection(new SQLitePlatformWinRT(), App.path);
        var Ingredients = new List<Ingredient>();
    
        {
            Ingredients = db.Table<Ingredient>().ToList();
        }
        foreach (var Ingredient in Ingredients)
        {
            IngredientsCollection.Add(Ingredient); //This is important
        }
        TestView.ItemsSource = IngredientsCollection;
        //TestView.ItemsSource = Ingredients;
    }
