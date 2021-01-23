        DragablePC _selected = null;
        Point cursorPos = new Point();
        private void DDPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (null == _selected) return;
            Point newPosition = e.GetPosition(DDPanel);
            _selected.PcColumn += newPosition.X - cursorPos.X;
            _selected.PcRow += newPosition.Y - cursorPos.Y;
            cursorPos = newPosition;
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var uiItem = sender as FrameworkElement;
            var dpc = uiItem.DataContext as DragablePC;
            if (dpc == null) return;
            cursorPos = e.GetPosition(DDPanel);
            _selected = dpc;
        }
        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var uiItem = sender as FrameworkElement;
            var dpc = uiItem.DataContext as DragablePC;
            if (dpc == null) return;
            _selected = null;
        }
