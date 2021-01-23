    foreach (var item in MYlistbox.items){
       if(Mystring.Contains(item.ToString())) {
           var lbItem = MYlistbox.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
           if(lbItem != null){
               lbItem.IsSelected = true;
           }
       }
    } 
