    // in the VM
    public IList<Order> SelectedOrders { /* regular RxUI property as usual */ }
  
    // in the view
    this.Grid.Events().SelectionChanged
        .Select(_ => this.Grid.SelectedItems.Cast<Order>().ToList())
        .Subscribe(list => ViewModel.SelectedOrders = list);
