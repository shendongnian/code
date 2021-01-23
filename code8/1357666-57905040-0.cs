      private void UIElement_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StartMousePosition = new System.Windows.Point(GetMousePositionWindowsForms().X, GetMousePositionWindowsForms().Y);
            
            MoveDragInformationPopup();
            DragInstrong textformationPopup.IsOpen = true;
        }
        private void UIElement_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (DragInformationPopup.IsOpen)
            {
                MoveDragInformationPopup();
            }
        }
        private void MoveDragInformationPopup()
        {
            var point = GetMousePositionWindowsForms();
            DragInformationPopup.HorizontalOffset = (point.X - StartMousePosition.X) + 5;
            DragInformationPopup.VerticalOffset = (point.Y - StartMousePosition.Y) + 5;
        }
        private System.Drawing.Point GetMousePositionWindowsForms()
        {
            return System.Windows.Forms.Control.MousePosition;
        }
