    private void MouseMovedWithTransparency()
    {
       Point lastCursorPos = new Point(-1, -1); // Starting point.
       while (this.Visible)
       {
            Point currentCursorPos = Cursor.Position;
            if (this.ContainsFocus && currentCursorPos.X > this.Left && currentCursorPos.X < this.Left + this.Width &&
                currentCursorPos.Y > this.Top && currentCursorPos.Y < this.Top + this.Height)
            {
                if ((currentCursorPos.X != lastCursorPos.X) || (currentCursorPos.Y != lastCursorPos.Y))
                {
                    // Do actions as in MouseMoved event.
                    // Save the new position, so it won't be triggered, when user doesn't move the cursor.
                    lastCursorPos = currentCursorPos;
                }
            }
            Application.DoEvents(); // UI must be kept responsive.
            Thread.Sleep(1);
        }
    }
