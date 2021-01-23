    void deleteItemFromListBox(string stringToDelete, ListView listBoxToDeleteItem)
    {
    for (int i = 0; i < listBoxToDeleteItem.Items.Count; i++)
    {
    if(stringToDelete==listBoxToDeleteItem.Items[i].Text)
    {
      listBoxToDeleteItem.Items[i].Remove();
    }
    }
    }
