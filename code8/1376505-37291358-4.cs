        /// <summary>
        /// helps to indicate the partial IsVisible state
        /// </summary>
        /// <param name="element">elemnt under the test</param>
        /// <param name="container">parent window or control</param>
        /// <returns></returns>
        private bool IsUserVisible(FrameworkElement element, FrameworkElement container)
        {
            if (!element.IsVisible)
                return false;
            Rect bounds = element.TransformToAncestor(container).TransformBounds(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
            Rect rect = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);
            return rect.Contains(bounds.TopLeft) || rect.Contains(bounds.BottomRight);
        }
