    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class ExNumericUpDown : NumericUpDown
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);
        private const int EM_SETMARGINS = 0xd3;
        private const int EC_RIGHTMARGIN = 2;
        private Label label;
        public ExNumericUpDown() : base()
        {
            var textBox = Controls[1];
            label = new Label() { Text = "MHz", Dock = DockStyle.Right, AutoSize = true };
            textBox.Controls.Add(label);
        }
        public string Label
        {
            get { return label.Text; }
            set { label.Text = value; if (IsHandleCreated) SetMargin(); }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            SetMargin();
            base.OnHandleCreated(e);
        }
        private void SetMargin()
        {
            SendMessage(Controls[1].Handle, EM_SETMARGINS, EC_RIGHTMARGIN, label.Width << 16);
        }
    }
