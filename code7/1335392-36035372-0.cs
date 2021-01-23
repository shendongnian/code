      private void ScannedDocContainer_MouseDown(object sender, MouseEventArgs e)
      {
         DoDragDrop((ScannedDocContainer)sender, DragDropEffects.Copy);    
      }
      private void ScannedDocContainer_DragDrop(object sender, DragEventArgs e)
      {
         if (e.Data.GetDataPresent(typeof(ScannedDocContainer)))
         {
            ScannedDocContainer docContainerDragged = (ScannedDocContainer)e.Data.GetData(typeof(ScannedDocContainer));
            ...
            "Extract the required data here"
            ...
         }
      }
