    // Get screenshot
                int width = rect.Right - rect.Left;
                int height = rect.Bottom - rect.Top;
                Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    IntPtr dc = g.GetHdc();
    
                    if (!PrintWindow(hWnd, dc, 0))
                    {
                        int error = Marshal.GetLastWin32Error();
                        var exception = new System.ComponentModel.Win32Exception(error);
                        Debug.WriteLine("ERROR: " + error + ": " + exception.Message);
                        return;
                    }
    
                    g.ReleaseHdc(dc);
                }
                
                // Save the screenshot
                bmp.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\test.jpg", ImageFormat.Jpeg);
                panel1.BackgroundImage = bmp;
