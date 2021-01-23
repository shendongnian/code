    public partial class form1 : Form, IMessageFilter 
    {
        private NativeWindow nw = null;
        public form1()
        {
            InitializeComponent();
            nw = new NativeWindow();
            nw.AssignHandle(this.listView1.Handle);
            Application.AddMessageFilter(this);
            // so you can see the selection moving when the arrow keys are pressed in the TextBox
            this.listView1.HideSelection = false;
            this.listView1.Items[0].Selected = true;
        }
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        public bool PreFilterMessage(ref Message m)
        {
            if (m.HWnd.Equals(this.textBox1.Handle))
            {
                switch (m.Msg)
                {
                    case WM_KEYDOWN:
                    case WM_KEYUP:
                        switch ((Keys)m.WParam)
                        {
                            case Keys.Up:
                            case Keys.Down:
                            case Keys.Right:
                            case Keys.Left:                               
                                m.HWnd = this.listView1.Handle; // change the handle to the ListView
                                nw.DefWndProc(ref m); // send the message to the ListView
                                return true; // suppress handling by the TextBox
                                break;
                        }
                        break;
                }
            }
            return false;
        }
    }
