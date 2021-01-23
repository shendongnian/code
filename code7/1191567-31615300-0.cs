    public void AddItemToList()
    {
        for (int i = 0; i < 10; i++)
        {
            System.Threading.Thread.Sleep(300);
            var AddItem = new Action(() => items.Add(new StructOfList { FirstName = "First", SecondName = "Second", Amount = i });
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, AddItem);
        }
    }
