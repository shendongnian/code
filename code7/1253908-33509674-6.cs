    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;
    public void PerformClick()
    {
        uint X = (uint)Cursor.Position.X;
        uint Y = (uint)Cursor.Position.Y;
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        //Just to keep the form on top
        this.TopMost = true;
        //Make form transparent and click through
        this.TransparencyKey = Color.Magenta;
        this.BackColor = Color.Magenta;
        //Make the button invisible and perform a click
        //The click reaches behind the button
        //Then make button visible again to be able handle clicks again
        this.button4.Visible = false;
        PerformClick();
        this.button4.Visible = true;
    }
