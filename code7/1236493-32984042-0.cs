         protected void ListViewGallery_ItemDrop(object sender, RadListViewItemDragDropEventArgs e)
         {
            if (e.DestinationHtmlElement.IndexOf("img-drop-zone") < 0)
            {
                return;
            }
            int newIndex = int.Parse(e.DestinationHtmlElement.Split('-').Last());
            int oldIndex = e.DraggedItem.DataItemIndex;
 
            ImagesList = MediaItem.MoveItem(ImagesList, (short)oldIndex, (short)newIndex);
            ListViewGallery.Rebind();
         }
