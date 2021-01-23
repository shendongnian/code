    private object myLock = new Object();
    void AddToList(SignalR s)
    {
        lock(myLock) {
            SignalR.Add(s);
        }
    }
    void UpdateList() {
        lock(myLock)
        {
            var r = SignalR.Where(...).ToList();
            Filter3List.ItemsSource = r;
            Filter3List.Items.Refresh();
        }
    }
