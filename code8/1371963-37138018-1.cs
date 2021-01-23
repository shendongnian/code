            if (mouse.LeftButton == ButtonState.Pressed)
            {
                Clicked = true;
            }
            else if (_color.A < 255)
            {
                _color.A += 3;
                Clicked = false;
            }
