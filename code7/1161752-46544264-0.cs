    private void MainTabControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReasonBecauseLeaveTabItemIsForbidden)
            {
                if (MainTabControl.SelectedIndex == IndexOfTabItem)
                {
                    MessageBox.Show(SomeMessageWhyLeaveTabItemIsForbidden);
                }
                MainTabControl.SelectedIndex = IndexOfTabItem;
            }
        }
