    public partial class myComboBox : ComboBox
    {
        public myComboBox()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        bool Invalid(int index)  // use your own logic here!
        {
            return (Items[index].ToString().StartsWith("X"));
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x111) /*  WM_COMMAND */
            {
                if (((int)m.WParam >> 16) == 1)
                {
                   if (Invalid(SelectedIndex))
                   {
                      Console.WriteLine(" bad boy! ");
                      m.Result = new IntPtr(1); // return success
                      return;                    // consume the message
                   }
                }
            }
            base.WndProc(ref m);
        }
    }
