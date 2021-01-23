    public partial class Form1 : Form
    {
        private const int WM_SETREDRAW = 0xB;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private Dictionary<string, string> replacements = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            replacements.Add("cx", "ĉ");
            replacements.Add("ae", "æ");
            // etc...
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int prevStart = richTextBox1.SelectionStart;
            int prevLength = richTextBox1.SelectionLength;
            SendMessage(richTextBox1.Handle, WM_SETREDRAW, false, 0);
            int index;
            int start;
            foreach (KeyValuePair<string,string> pair in replacements)
            {
                start = 0;
                index = richTextBox1.Find(pair.Key, start, RichTextBoxFinds.None);
                while (index != -1)
                {
                    richTextBox1.Select(index, pair.Key.Length);
                    richTextBox1.SelectedText = pair.Value;
                    index = richTextBox1.Find(pair.Key, ++start, RichTextBoxFinds.None);
                }
            }
            richTextBox1.Select(prevStart, prevLength);
            SendMessage(richTextBox1.Handle, WM_SETREDRAW, true, 0);
            richTextBox1.Invalidate();
        }
    }
