    private bool favoritesEnabled;
    public bool FavoritesEnabled
    {
        get
        {
            return this.favoritesEnabled;
        }
        set
        {
            this.favoritesEnabled = value;
            this.RootNodes = value == true
                ? new ObservableCollection(this.FilterFavorites)
                : new ObservableCollection(this.CreateRootNodes);
        }
    }
    private IEnumerable<INode> FilterFavorites()
    {
        List<INode> nodes = new List<INode>();
        foreach(DirectoryNode directory in this.RootNodes.OfType<DirectoryNode>())
        {
            nodes.AddRange(this.filterFavorites(nodes, directory.Children.OfType<DirectoryNode>());
            nodes.AddRange(this.RootNodes.OfType<FileNode>().Where(item => item.IsFavorite);
        }
    }
    private List<INode> FilterFavorites(List<INode> filteredResults, IEnumerable<DirectoryInfo> directories)
    {
        // Recursively look up all favorites.
        foreach(DirectoryNode directory in directories)
        {
            filteredResults.AddRange(FilterFavorites(filteredResults, directory));
        }
            nodes.AddRange(this.RootNodes.OfType<FileNode>().Where(item => item.IsFavorite);
        return filteredResults;
    }
