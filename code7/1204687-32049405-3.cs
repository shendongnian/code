     private void MoveCustomCaret()
        {
            var caretLocation = this.GetRectFromCharacterIndex(this.CaretIndex).Location;
            if (!double.IsInfinity(caretLocation.X))
            {
                Canvas.SetLeft(border, caretLocation.X);
            }
            if (!double.IsInfinity(caretLocation.Y))
            {
                Canvas.SetTop(border, caretLocation.Y);
            }
        }
