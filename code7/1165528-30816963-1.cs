    private void Grd1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = ((StackPanel)e.ClickedItem);
            if (clickedItem.Tag != null)
                if (clickedItem.Tag.ToString() == "Grid1")
                    Frame.Navigate(typeof(Page1));
                else
                    Frame.Navigate(typeof(Page2));
        }
