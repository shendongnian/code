    // use global variable
    ObservableCollection<BoolStringClass> TheList;
    public void CreateCheckBoxList()
    {
        //some code that creates a list
        TheList = new ObservableCollection<BoolStringClass>() { 
            new BoolStringClass() {TheText = "Check1", TheValue = false},
            new BoolStringClass() {TheText = "Check2", TheValue = true} 
        }
    }
