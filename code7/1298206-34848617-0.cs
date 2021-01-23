    public ICommand RemoveCommand { get { return new RelayCommand<Product>(OnRemove); } }
    private void OnRemove(Product product)
    {
        // remove it here
    }
