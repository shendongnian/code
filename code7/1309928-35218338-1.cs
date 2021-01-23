    private void Form1_Paint(object sender, PaintEventArgs e)
            {
                IntPtr desktop = GetDC(IntPtr.Zero);
                using (Graphics g = Graphics.FromHdc(desktop))
                {
                    g.FillRectangle(Brushes.Red, 0, 0, 100, 100);
                }
                ReleaseDC(IntPtr.Zero, desktop);
            }
