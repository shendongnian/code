    <ListBox ItemsSource="{Binding Categories}"
        SelectedItem="{Binding SelectedCategory}" ... />
..
    public Category SelectedCategory
    {
        get { return selectedCategory; }
        set
        {
            if (selectedCategory != value)
            {
                selectedCategory = value;
                NotifyPropertyChanged("SelectedCategory");
                // Selected Category was changed, so update Articles collection
                Articles = UpdateArticlesByCategory(selectedCategory);
            }
        }
    }
