    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public class FlatCombo : ComboBox
    {
        private const int WM_PAINT = 0xF;
        private int buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth;
        Color borderColor = Color.Blue;
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT && DropDownStyle != ComboBoxStyle.Simple)
            {
                using (var g = Graphics.FromHwnd(Handle))
                {
                    var d = FlatStyle == FlatStyle.Popup ? 1 : 0;
                    var innerBorderWisth = 3;
                    var innerBorderColor = Enabled ? BackColor : SystemColors.Control;
                    if (DropDownStyle == ComboBoxStyle.DropDownList)
                        innerBorderColor = Color.FromArgb(0xCCCCCC);
                    if (DropDownStyle == ComboBoxStyle.DropDown || Enabled == false)
                    {
                        using (var p = new Pen(innerBorderColor, innerBorderWisth))
                        {
                            p.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                            g.DrawRectangle(p, 1, 1, Width - buttonWidth - d - 1, Height - 1);
                        }
                    }
                    using (var p = new Pen(BorderColor))
                    {
                        g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
                        g.DrawLine(p, Width - buttonWidth - d, 
                        0, Width - buttonWidth - d, Height);
                    }
                }
                m.Result = IntPtr.Zero;
            }
        }
    }
