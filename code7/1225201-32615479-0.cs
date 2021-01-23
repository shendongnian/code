    Container c = new Container();
    // Code in thread1
    c.Add(new Item());
    // Code in thread2
    foreach (var item in c.Items) {
        ...
    }
