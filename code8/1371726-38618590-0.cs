    homeLW.Loaded += DisableSelectedItemsOnLoad()
    
    private void DisableSelectedItemsOnLoad()
    {
    
         foreach(var lwI in homeLW.Items)
                {
                  ListViewItem item =(ListViewItem)homeLW.ContainerFromItem(lwI);
                  item.IsEnabled = false;
                }
    }
