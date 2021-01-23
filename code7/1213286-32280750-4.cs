    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    namespace CustomControls
    {
        public class CustomPaintTextBox : NativeWindow
        {
            private TextBox parentTextBox;
            private const int WM_PAINT = 15;
            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM_PAINT: 
                        // invalidate textbox to make it refresh
                        parentTextBox.Invalidate();
                        // call default paint
                        base.WndProc(ref m);
                        // draw custom paint
                        this.CustomPaint();
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            }
            public CustomPaintTextBox(TextBox textBox)
            {
                this.parentTextBox = textBox;
                textBox.TextChanged += textBox_TextChanged;
                // subscribe for messages
                this.AssignHandle(textBox.Handle);
            }
            void textBox_TextChanged(object sender, EventArgs e)
            {
                CustomPaint();
            }
            private void CustomPaint()
            {
                var g= this.parentTextBox.CreateGraphics();
                float y = 0;
                var lineHeight = g.MeasureString("X", this.parentTextBox.Font).Height;
                while (y < this.parentTextBox.Height)
                {
                    y += lineHeight;
                    g.DrawLine(Pens.Red, 0f, y, (float)this.parentTextBox.Width, y);
                }
            }
        }
    }
