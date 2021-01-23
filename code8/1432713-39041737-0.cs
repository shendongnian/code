    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Linq;
<!---->
    public class MyComboBox : ComboBox
    {
        private const UInt32 WM_CTLCOLORLISTBOX = 0x0134;
        private const int SWP_NOSIZE = 0x1;
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
            int X, int Y, int cx, int cy, uint uFlags);
        public enum DropDownAlignments { Left = 0, Middle, Right }
        public bool AutoWidthDropDown { get; set; }
        public DropDownAlignments DropDownAlignment { get; set; }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CTLCOLORLISTBOX)  {
                var bottomLeft = this.PointToScreen(new Point(0, Height));
                var x = bottomLeft.X;
                if (DropDownAlignment == MyComboBox.DropDownAlignments.Middle)
                    x -= (DropDownWidth - Width) / 2;
                else if (DropDownAlignment == DropDownAlignments.Right)
                    x -= (DropDownWidth - Width);
                var y = bottomLeft.Y;
                SetWindowPos(m.LParam, IntPtr.Zero, x, y, 0, 0, SWP_NOSIZE);
            }
            base.WndProc(ref m);
        }
        protected override void OnDropDown(EventArgs e)
        {
            if (AutoWidthDropDown)
                DropDownWidth = Items.Cast<Object>().Select(x => GetItemText(x))
                      .Max(x => TextRenderer.MeasureText(x, Font,
                           Size.Empty, TextFormatFlags.Default).Width);
            else
                DropDownWidth = this.Width;
            base.OnDropDown(e);
        }
    }
