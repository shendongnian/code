        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                var obj = ContainerFromElement((Visual) e.OriginalSource);
                if (obj == null)
                    return;`
                var fe = obj as FrameworkElement;
                var item = fe as ListBoxItem;
                if (item != null)
                {
                    SelectedItem = item.DataContext;
                }
            }
        }
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            if(e.LeftButton != MouseButtonState.Pressed)
                e.Handled = true;
        }
