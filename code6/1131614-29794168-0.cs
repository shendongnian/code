    for (int i = 0; i < TempList.Count; i++)
    {
        if (Order_TempList[i].txt == ((Items1)listview.SelectedItem).txt)
        {
            ((Items1)listview.SelectedItem).txt = Order_TempList[i].txt;
            i = TempList.Count;
        }
    }
