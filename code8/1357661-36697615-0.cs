    private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                var mousePoint = Mouse.GetPosition(this);
                dragPopup.HorizontalOffset = mousePoint.X + this.Left + 10;
                dragPopup.VerticalOffset = mousePoint.Y + this.Top + 10;
                dragPopup.IsOpen = true;
            }
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePoint = Mouse.GetPosition(this);
            dragPopup.HorizontalOffset = mousePoint.X + this.Left + 10;
            dragPopup.VerticalOffset = mousePoint.Y + this.Top + 10;     
        }
