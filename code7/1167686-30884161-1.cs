    listview.Sorting = System.Windows.Forms.SortOrder.Ascending;
    for (int i = 0; i < listview.Items.Count - 1; i++)
    {
       if (listview.Items[i].Tag.Equals(listview.Items[i + 1].Tag))
       {
          listview.Items[i + 1].Remove();
          i--;
       }
    }
