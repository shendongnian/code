    static ObservableCollection<TreeViewItemModel> GetSpaceTree(
        IEnumerable<Space> spaces)
    {
        return new ObservableCollection<TreeViewItemModel>(
            spaces
                .Where(space => space.Parent == null)
                .Select(space => new TreeViewSpaceModel(space))
        );
    }
