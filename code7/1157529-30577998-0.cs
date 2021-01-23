    //do as much work as possible in background thread
    var items = new MyClass[100000];
    for (int i = 0; i < 1000000; i++) {
       items[i] = new MyClass{ MyInt = i;}
    }
    Dispatcher.BeginInvoke(new Action(() => //update UI just once
       MyModel.MyCollection = new ObservableCollection(items);
    ));
