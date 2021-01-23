    public ObservableCollection<object> myCollection { set; get; } 
    ....
    myCollection = new ObservableCollection<object>();
    myViewModelForItemA anItem = new myViewModelForItemA();
    myCollection.Add(anItem);
    //now anItem of type (myViewModelForItemA) is in our collection
    //and the ItemsControl automagically added a CheckBox to it's collection
    //and bound isChecked to anItem.isChecked property, and bound
    //the Content to anItem.aName property.
