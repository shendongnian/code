    using System.Runtime.InteropServices;
    //..
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int GetScrollPos(int hWnd, int nBar);
    [DllImport("user32.dll")]
    static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
    private const int SB_HORZ = 0x0;
    private const int SB_VERT = 0x1;
     // bring your node into the display
    someNode.EnsureVisible();
    // now you can scroll back to the left:
    SetScrollPos(treeView1.Handle, SB_HORZ, 0, true);
