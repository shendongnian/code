    bool activated;
        Point point;
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            activated = true;
            point = e.GetPosition(container);
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (activated)
            {
                translate.X = e.GetPosition(container).X - point.X;
                translate.Y = e.GetPosition(container).Y - point.Y;
            }
        }
        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            activated = false;
        }
