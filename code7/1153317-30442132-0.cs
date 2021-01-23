        Rectangle rect = new Rectangle(button1.Location, button1.Size);
        for (int i = 0; i < _points.Count; i++)
        {
            if (rect.Contains(_points[i]))
            {
                button1.PerformClick();
            }
        }
