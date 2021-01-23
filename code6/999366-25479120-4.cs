        /// <summary>
        /// Show the form in the little control panel preview window.
        /// </summary>
        /// <param name="hWnd">hwnd passed to us at launch by windows</param>
        static void ShowMiniPreview(IntPtr hWnd)
        {
            if (NativeMethods.IsWindow(hWnd))
            {
                miniControlPanelForm preview = new miniControlPanelForm(hWnd);
                IntPtr newParent = NativeMethods.SetParent(preview.Handle, hWnd);
                // Set the size of the form to the size of the parent window (using the passed hWnd).
                System.Drawing.Rectangle ParentRect = new System.Drawing.Rectangle();
                bool fSuccess = NativeMethods.GetClientRect(hWnd, ref ParentRect);
                // Set our size to new rect and location at (0, 0)
                preview.Size = ParentRect.Size;
                preview.Location = new System.Drawing.Point(0, 0);
                // Show the form
                preview.Show();
                // and run it
                Application.Run(preview);
            }
        }
