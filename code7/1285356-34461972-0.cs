       MyItem item = Dgrd.ItemContainerGenerator.ItemFromContainer(e.Row) as MyItem;
       if (item != null)
       {
           System.Diagnostics.Debug.WriteLine(item.Name);
       }
