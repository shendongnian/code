    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace TestPaintApp
    {
        public class TestPaint : Form
        {
            private bool drawLine = false;
            private Point lineStart;
            private Point lineEnd;
            public TestPaint()
            {
                var drawLineButton = new Button();
                drawLineButton.Text = "Draw line";
                drawLineButton.Location = new Point(5, 5);
                drawLineButton.Click += DrawLineButton_Click;
                var dontDrawLineButton = new Button();
                dontDrawLineButton.Text = "Don't draw";
                dontDrawLineButton.Location = new Point(5, 30);
                dontDrawLineButton.Click += DontDrawLineButton_Click;
                GetLineRect();
                this.Controls.Add(drawLineButton);
                this.Controls.Add(dontDrawLineButton);
                this.MinimumSize = new Size(200, 200);
                this.Paint += Form_Paint;
                this.Resize += Control_Resize;
            }
            private Rectangle GetLineRect()
            {
                this.lineStart = new Point(75, 75);
                this.lineEnd = new Point(this.ClientSize.Width - 75, this.ClientSize.Height - 75);
                return new Rectangle(
                    Math.Min(lineStart.X, lineEnd.X),
                    Math.Min(lineStart.Y, lineEnd.Y),
                    Math.Max(lineStart.X, lineEnd.X),
                    Math.Max(lineStart.Y, lineEnd.Y)
                    );
            }
            private void Form_Paint(object sender, PaintEventArgs e)
            {
                if (drawLine)
                {
                    e.Graphics.DrawLine(Pens.Red, lineStart, lineEnd);
                }
            }
            private void Control_Resize(object sender, EventArgs e)
            {
                this.Invalidate(GetLineRect());
            }
            private void DrawLineButton_Click(object sender, EventArgs e)
            {
                drawLine = true;
                this.Invalidate(GetLineRect());
            }
            private void DontDrawLineButton_Click(object sender, EventArgs e)
            {
                drawLine = false;
                this.Invalidate(GetLineRect());
            }
        }
    }
