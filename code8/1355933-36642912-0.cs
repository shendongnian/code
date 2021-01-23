    //Your Copy List
    ObservableCollection<CategoryModel> _ReceivedCategories;
    //Your Execute command for the Gui
    public void onUpdateExecuted(object parameter){
    Dispatcher.Invoke(new Action(() => ReceivedCategories = new ObservableCollection <CategoryModel> (_ReceivedCategories));
    }
    //Your Undo Command if the Inputs are not ok
    public void onUndoExecuted(object parameter){
    Dispatcher.Invoke(new Action(() => _ReceivedCategories = new ObservableCollection <CategoryModel> (ReceivedCategories));
    }
    //Your Command on every input which is set
    public void onInputExecuted(object parameter){
    _ReceivedCategories.add(Your Object);
    }
    
