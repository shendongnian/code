    public class OldProgressBar : ProgressBar {
      [DllImportAttribute("uxtheme.dll")]
      private static extern int SetWindowTheme(IntPtr hWnd, string appName, string idlist);
      protected override void OnHandleCreated(EventArgs e) {
        SetWindowTheme(this.Handle, "", "");
        base.OnHandleCreated(e);
      }
    }
