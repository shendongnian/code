    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool EnableWindow(IntPtr hWnd, bool bEnable);
    
    private void ModalDialog_Shown(object sender, EventArgs e)
    {
        for (int i = 0; i < Application.OpenForms.Count; i++)
        {
            var f = Application.OpenForms[i];
            if (f is OtherDialogWichShouldBeOverModal)
            {
                EnableWindow(f.Handle, true);
                f.Activate();
                //...
            }
        }
    }
