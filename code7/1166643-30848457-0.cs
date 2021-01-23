      private DataGridRow row;
      private void dgArtikel_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
      {
       if (row != null)
          row.Background = Brushes.White;
       listViewItems itm = (listViewItems)dgArtikel.SelectedItem;
       row = dgArtikel.ItemContainerGenerator.ContainerFromItem(itm) as DataGridRow;
       row.Background = Brushes.YellowGreen;
      }
