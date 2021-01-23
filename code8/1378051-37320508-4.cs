    public partial class myComboBox : ComboBox
    {
        public myComboBox()
        {
            InitializeComponent();
        }
        private int direction = 0;  // where to jump when when doing keyboard selection
        private int lastIndex = -1;
        private void skip()
        {
            if (direction > 0 && (SelectedIndex + 1 < Items.Count))
                SelectedIndex += 1;
            else if (direction < 0 && (SelectedIndex - 1 >= 0))
                SelectedIndex -= 1;
            else SelectedIndex = lastIndex;
        }
        // optional, but you are owner-drawing anyway..
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        // use your own logic to determine which entries can be selected!
        bool Invalid(int index)
        {
            return index < 0 ? true 
                             : (Items[index].ToString().StartsWith("X"));
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) direction = -1;
            else if (e.KeyCode == Keys.Down) direction = 1;
            else direction = 0;
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x111) /*  WM_COMMAND */
            {
                if (((int)m.WParam >> 16) == 1)
                {
                    if (Invalid(SelectedIndex))
                    {
                        while (Invalid(SelectedIndex)) skip();  // skip invalid entries
                        m.Result = new IntPtr(1); // return success
                        return;                   // consume the message
                    }
                    lastIndex = SelectedIndex;
                }
            }
            base.WndProc(ref m);
        }
      }
    }
