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
            private Bitmap bitmap;
            private Graphics textBoxGraphics;
            private Graphics bufferGraphics;
            // this is where we intercept the Paint event for the TextBox at the OS level
            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case 15: // this is the WM_PAINT message
                        // invalidate the TextBox so that it gets refreshed properly
                        parentTextBox.Invalidate();
                        // call the default win32 Paint method for the TextBox first
                        base.WndProc(ref m);
                        // now use our code to draw extra stuff over the TextBox
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
                this.bitmap = new Bitmap(textBox.Width, textBox.Height);
                this.bufferGraphics = Graphics.FromImage(this.bitmap);
                this.bufferGraphics.Clip = new Region(textBox.ClientRectangle);
                this.textBoxGraphics = Graphics.FromHwnd(textBox.Handle);
                // Start receiving messages (make sure you call ReleaseHandle on Dispose):
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
