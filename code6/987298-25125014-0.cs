    private void btnProcessMedia_Click(object sender, RoutedEventArgs e)
    {
      if (dgProjects.SelectedItems.Count > 0)
      {
        for (int i = 0; i < dgProjects.SelectedItems.Count; i++)
        {
          System.Data.DataRowView selectedFile = (System.Data.DataRowView)dgProjects.SelectedItems[i];
          string str = Convert.ToString(selectedFile.Row.ItemArray[10]);
        }
      }
    }
