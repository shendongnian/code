    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewmodel = (CategoriesViewModel)DataContext;
            if (LstCategories.SelectedIndex > -1)
                viewmodel.CurrentCategory = LstCategories.SelectedItems.Cast<CategoryModel>().FirstOrDefault();
        }
