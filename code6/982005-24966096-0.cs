    private void button1_Click(object sender, System.EventArgs e)
    {
    SendMessage(GetDesktopWindow(), LVM_ARRANGE, LVA_SNAPTOGRID , 0);
    }
     
    
    public const int LVM_ARRANGE = 4118;
    public const int LVA_SNAPTOGRID = 5;
    
     
    [DllImport("User32.dll", CharSet=CharSet.Auto)]
    public static extern IntPtr GetDesktopWindow();
     
    [DllImport("user32.dll")] 
    public static extern int SendMessage( IntPtr hWnd, uint Msg, int wParam, int lParam ); 
