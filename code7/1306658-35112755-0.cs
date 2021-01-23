    public void Refresh(ObservableCollection<Item> myList, List<Item> newItems)
    {
        for(int i = 0; i < newItems.Count; i++)
        {
            myList.Insert(i, newItem=newItems[i]);
        }
    }
