        foreach (var s in Screen.AllScreens) //System.Windows.Forms.Screen
        {
            var b = s.Bounds;
            var w = new PopupWindow();
            var oW = w.Width; //Keep track of original size ...
            var oH = w.Height;
            w.Width = 0; //then set the size to 0, to avoid that the 
            w.Height = 0;//popup shows before it is correctly positioned
            w.Show(); //Now show it, so that we can place it (when I
                      //tried to place it before showing, the window
                      //was always repositioned when Show() was called)
            double dpiX = 1, dpiY = 1;
            var ps = PresentationSource.FromVisual(w);
            if (ps != null)
            {
                dpiX = ps.CompositionTarget.TransformToDevice.M11;
                dpiY = ps.CompositionTarget.TransformToDevice.M22;
            }
            var aW = oW*dpiX; //Calculate the actual size of the window
            var aH = oH*dpiY;
            w.Left = (b.X + (b.Width - aW) / 2) / dpiX;
            w.Top = (b.Y + (b.Height - aH) / 2) / dpiX;
            w.Width = oW; //And set the size back to the original size
            w.Height = oH;
        }
