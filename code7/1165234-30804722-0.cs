        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pnt);
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            IntPtr hWnd = WindowFromPoint(Control.MousePosition);
            if(hWnd !=IntPtr.Zero)
            {
                Control control = Control.FromChildHandle(hWnd);
                if (control != null)
                {
                    if(control==buttonOne || control==buttonTwo || control==buttonThree )
                        return;
                }
            }
            this.buttonOne.Visible = false;
            this.buttonTwo.Visible = false;
            this.buttonThree.Visible = false;
        }
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.buttonOne.Visible = true;
            this.buttonTwo.Visible = true;
            this.buttonThree.Visible = true;
        }
        private void button_Click(object sender, EventArgs e)
        {
            Control control=(Control)sender;
            MessageBox.Show(control.Text);
        }
