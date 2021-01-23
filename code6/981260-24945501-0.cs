    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<TextBox> TextBoxes = new List<TextBox>();
            FindTextBoxes(this, TextBoxes);
            Application.AddMessageFilter(new SuppressTextBoxClicks(TextBoxes));
        }
        private void FindTextBoxes(Control ctl, List<TextBox> TBs)
        {
            foreach(Control childCtl in ctl.Controls)
            {
                if (childCtl is TextBox)
                {
                    TBs.Add((TextBox)childCtl);
                }
                else if(childCtl.HasChildren)
                {
                    FindTextBoxes(childCtl, TBs);
                }
            }
        }
    }
    public class SuppressTextBoxClicks : IMessageFilter
    {
        private List<TextBox> _TextBoxes = null;
        private const int WM_LBUTTONDOWN = 0x201;
        public SuppressTextBoxClicks(List<TextBox> TextBoxes)
        {
            _TextBoxes = TextBoxes;
        }
        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_LBUTTONDOWN:
                    if (_TextBoxes != null)
                    { 
                        foreach(TextBox TB in _TextBoxes)
                        {
                            if (TB.Handle.Equals(m.HWnd))
                            {
                                return true;
                            }
                        }
                    }
                    
                    break;
                default:
                    break;
            }
            return false;
        }
    }
