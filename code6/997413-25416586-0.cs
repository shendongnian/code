    if (option.Button1.Contains(MousePosition))
    {
       if (mouseState.RightButton == ButtonState.Pressed)
        {
           graphics.IsFullScreen = !graphics.IsFullScreen;
           graphics.ApplyChanges();
        }
     }
