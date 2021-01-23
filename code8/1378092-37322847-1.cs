        private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) 
        {
            // Update the mouse path with the mouse information
            Point mouseDownLocation = new Point(e.X, e.Y);
            string eventString = null;
            switch (e.Button) {
                case MouseButtons.Left:
                    eventString = "L";
                    break;
                case MouseButtons.Right:
                    eventString = "R";
                    break;
                case MouseButtons.Middle:
                    eventString = "M";
                    break;
                case MouseButtons.XButton1:
                    eventString = "X1";
                    break;
                case MouseButtons.XButton2:
                    eventString = "X2";
                    break;
                case MouseButtons.None:
                default:
                    break;
            }
