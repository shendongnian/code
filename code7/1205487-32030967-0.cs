     public partial class Form1 : Form
     {
        const int MfByposition = 0x400;
        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        public Form1()
        {
            InitializeComponent();
            var hMenu = GetSystemMenu(Handle, false);
            var menuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, menuItemCount - 1, MfByposition);
            ...
        }
    }
