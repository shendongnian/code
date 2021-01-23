    public static UserControl FrameControl(Size size, Point location)
        {
            UserControl frame = new UserControl();
            frame.Location =  location;
            frame.Size =  size;
            frame.BorderStyle = BorderStyle.Fixed3D;
            frame.BackColor = Color.Transparent;
    
            return frame;
        }
    
