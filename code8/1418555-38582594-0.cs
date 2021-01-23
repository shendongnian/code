    private void Obj_GetDataFromChild(bool IsVisible)
        {
            if (IsVisible)
                LoadingGrid.Visibility = Visibility.Visible;
            else 
                LoadingGrid.Visibility = Visibility.Collapsed;
        }
