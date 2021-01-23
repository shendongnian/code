    private void ToggleItemInList(object param)
    {
        int item;
        if (int.TryParse(param.ToString(), out item))
        {
           //If its actually an int
           if (myList.Contains(item))
               myList.Remove(item);
           else
               myList.Add(item);
        }
    }
