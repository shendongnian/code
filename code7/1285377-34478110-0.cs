     private async void IconGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = sender as GridView;
            if (e.ClickedItem == gridView.SelectedItem)
            {
                await Task.Delay(100);
                gridView.SelectedItem = null;
            }
        }
