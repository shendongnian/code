        public void ScrollSlide(UITestControl scrollBar)
        {
            Point bottomOfScrollBar = new Point(scrollBar.Left + (scrollBar.Width / 2), scrollBar.Top + (scrollBar.Height - (scrollBar.Height / 20)
            Mouse.Move(null, new Point(scrollBar.Left + (scrollBar.Width / 2), scrollBar.Top + (scrollBar.Height - (scrollBar.Height / 15))));
            Mouse.Move(null, bottomOfScrollBar )));
            Mouse.DoubleClick(null, bottomOfScrollBar ))));
            Mouse.DoubleClick(null, bottomOfScrollBar )));
            Mouse.DoubleClick(null, bottomOfScrollBar )));
        }
