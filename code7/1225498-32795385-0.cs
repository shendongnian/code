        private static void Get_position(object sender, MouseButtonEventArgs e)
        {
            DependencyObject parent = e.OriginalSource as UIElement;
            while (parent != null && !(parent is Canvas))
                parent = VisualTreeHelper.GetParent(parent);
            if (parent != null)
            {
                var point = e.GetPosition(parent as UIElement);
                int x = (int)point.X;
                int y = (int)point.Y;
            }
        }
