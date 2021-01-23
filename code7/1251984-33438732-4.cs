     static private void myControl_MouseMove(object sender,System.Windows.Forms.MouseEventArgs e)
     {
       IntPtr hdc = GetDC(IntPtr.Zero); 
       uint pixel = GetPixel(hdc, Cursor.Position.X, Cursor.Position.Y);
       ReleaseDC(IntPtr.Zero,hdc);
       Color color = Color.FromArgb((int)pixel);
       Console.WriteLine("Color is {0}",color);
     }
