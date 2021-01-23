    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Drawing;
    public class ExTextBox : TextBox
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hwnd, int msg,
            int wParam, int lParam);
        private const int EM_SETMARGINS = 0xd3;
        private const int EC_RIGHTMARGIN = 2;
        private const int EC_LEFTMARGIN = 1;
        private Label label;
        public ExTextBox()
            : base()
        {
            label = new Label() {Dock = DockStyle.Bottom, Height = 2, BackColor = Color.Gray};
            Padding = new Padding(10,0,10,0);
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            AutoSize = false;
            Controls.Add(label);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetMargin();
        }
        private void SetMargin()
        {
            SendMessage(Handle, EM_SETMARGINS, EC_RIGHTMARGIN, Padding.Right << 16);
            SendMessage(Handle, EM_SETMARGINS, EC_LEFTMARGIN, Padding.Left);
        }
    }
