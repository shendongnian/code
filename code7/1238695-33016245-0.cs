    private void OnIsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs args)
        {
            if (args.IsBrowserInitialized)
            {
                ChromeWidgetMessageInterceptor.SetupLoop((ChromiumWebBrowser)Browser, (message) =>
                {
                    const int WM_MOUSEACTIVATE = 0x0021;
                    const int WM_NCLBUTTONDOWN = 0x00A1;
                    if (message.Msg == WM_MOUSEACTIVATE) {
                        // The default processing of WM_MOUSEACTIVATE results in MA_NOACTIVATE,
                        // and the subsequent mouse click is eaten by Chrome.
                        // This means any .NET ToolStrip or ContextMenuStrip does not get closed.
                        // By posting a WM_NCLBUTTONDOWN message to a harmless co-ordinate of the
                        // top-level window, we rely on the ToolStripManager's message handling
                        // to close any open dropdowns:
                        // http://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/ToolStripManager.cs,1249
                        var topLevelWindowHandle = message.WParam;
                        PostMessage(topLevelWindowHandle, WM_NCLBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
                    }
                });
            }
        }
