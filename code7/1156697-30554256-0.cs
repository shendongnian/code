        if(lstView.SelectedItems.Count=0)
        {
          return;
        }
        var selectedItem=lstView.SelectedItem[0] as FrameWorkElement;
        var itemDataContext=selectedItem.DataContext as Article;
        if(itemDataContext!=null)
        {
            //do what you like with the object
            string idString=itemDataContext.id;
        }
