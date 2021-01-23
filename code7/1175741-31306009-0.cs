        private void ShowPreview(IntPtr hWnd)
        {
            if (NativeMethods.IsWindow(hWnd))
            {
                // Get the rect of the desired parent.
                int error = 0;
                System.Drawing.Rectangle ParentRect = new System.Drawing.Rectangle();
                NativeMethods.SetLastErrorEx(0, 0);
                bool fSuccess = NativeMethods.GetClientRect(hWnd, ref ParentRect);
                error = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                // Create the HwndSource which will host our Preview user control
                HwndSourceParameters parameters = new HwndSourceParameters();
                parameters.WindowStyle = NativeMethods.WindowStyles.WS_CHILD | NativeMethods.WindowStyles.WS_VISIBLE;
                parameters.SetPosition(0, 0);
                parameters.SetSize(ParentRect.Width, ParentRect.Height);
                parameters.ParentWindow = hWnd;
                HwndSource src = new HwndSource(parameters);
                // Create the user control and attach it
                PreviewControl Preview = new PreviewControl();
                src.RootVisual = Preview;
                Preview.Visibility = Visibility.Visible;
            }
        }
