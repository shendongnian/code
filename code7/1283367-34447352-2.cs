    public Recipe RecipeData { get; set; }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is int)
        {
            RecipeData = GetRecipe((int)e.Parameter);
        }
        else
        {
            //Something Wrong
        }
    
        base.OnNavigatedTo(e);
    }
