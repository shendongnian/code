    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewmodel = (CategoriesViewModel)DataContext;
            viewmodel.CurrentCategory = LstCategories.SelectedItems.Cast<CategoryModel>().FirstOrDefault();
        }
