    public partial class Form1 : Form, IMessageFilter
    {
        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
        }
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x0201) // This is left click
            {
                var ctrl = Control.FromHandle(m.HWnd);
                if (ctrl is Button)
                    Debug.WriteLine(ctrl.Name);
            }
            return false;
        }
    }
