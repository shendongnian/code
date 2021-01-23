    public ICommand SpinnerSelected => new MvxCommand<Dictionary<string, object>>(item =>
        {
            var selectedItem = item["SelectedItem"] as ListItemModel;//Cast to the actual model
            var index = item["Index"] as int?;//The index of the collection to update
        });
