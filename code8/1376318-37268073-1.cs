            protected override void OnRightTapped(RightTappedRoutedEventArgs e)
        {
            ShowContextMenu(null, e.GetPosition(null));
            e.Handled = true;
            base.OnRightTapped(e);
        }
        private void ShowContextMenu(UIElement target, Point offset)
        {
            var MyFlyout = this.Resources["SampleContextMenu"] as MenuFlyout;
            MyFlyout.ShowAt(target, offset);
        }
