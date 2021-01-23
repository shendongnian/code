    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WASD_Keyboard
    {
        public partial class Form1 : Form
        {
            private PictureBox pictureBox1 = new PictureBox();
            private bool wPressed = false;
            private bool aPressed = false;
            private bool sPressed = false;
            private bool dPressed = false;
            private Timer timer = new Timer();
            public Form1()
            {
                InitializeComponent();
                //Stay always on top
                this.TopMost = true;
                //Does not work. Removes border but you can't move the window after this
                this.FormBorderStyle = FormBorderStyle.None;
                timer.Interval = 3000;
                timer.Tick += timer1_Tick;
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                // Dock the PictureBox to the form and set its background to white.
                pictureBox1.Dock = DockStyle.Fill;
                pictureBox1.BackColor = Color.White;
                pictureBox1.Paint += DrawRectangleRectangle;
                // Add the PictureBox control to the Form.
                this.Controls.Add(pictureBox1);
            }
            private void Form1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar < 65 || e.KeyChar > 122) return;
                wPressed = false;
                aPressed = false;
                sPressed = false;
                dPressed = false;
                switch (e.KeyChar)
                {
                    //If pressed w or W
                    case (char) 119:
                    case (char) 87:
                        wPressed = true;
                        Console.WriteLine(e.KeyChar);
                        break;
                    //If pressed a or A
                    case (char) 97:
                    case (char) 65:
                        aPressed = true;
                        Console.WriteLine(e.KeyChar);
                        break;
                    //If pressed s or S
                    case (char) 83:
                    case (char) 115:
                        sPressed = true;
                        Console.WriteLine(e.KeyChar);
                        break;
                    //If pressed d or D
                    case (char) 100:
                    case (char) 68:
                        dPressed = true;
                        Console.WriteLine(e.KeyChar);
                        break;
                    //Something goes wrong
                    default:
                        lblMessage.Text = "Key not supported";
                        break;
                }
                pictureBox1.Refresh();
                timer.Enabled = true;
                timer.Start();
            }
            public void DrawRectangleRectangle(object sender, PaintEventArgs e)
            {
                DrawRectangle(e, new Point(40, 10), new Size(20, 20), 'W', wPressed ? Color.Red : Color.White);
                DrawRectangle(e, new Point(10, 40), new Size(20, 20), 'A', aPressed ? Color.Red : Color.White);
                DrawRectangle(e, new Point(40, 40), new Size(20, 20), 'S', sPressed ? Color.Red : Color.White);
                DrawRectangle(e, new Point(70, 40), new Size(20, 20), 'D', dPressed ? Color.Red : Color.White);
            }
            public void DrawRectangle(PaintEventArgs e, Point p, Size s, char letter, Color c)
            {
                // Create pen.
                var blackPen = new Pen(Color.Black, 3);
                var brush = new SolidBrush(c);
                // Create rectangle.
                var rect = new Rectangle(p, s);
            
                // Draw rectangle to screen.
                e.Graphics.DrawRectangle(blackPen, rect);
                e.Graphics.FillRectangle(brush, rect);
                e.Graphics.DrawString(letter.ToString(), new Font(FontFamily.GenericSerif, 12), Brushes.Blue, rect);
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                wPressed = false;
                aPressed = false;
                sPressed = false;
                dPressed = false;
                timer.Enabled = false;
                timer.Stop();
                pictureBox1.Refresh();
            }
        }
    }
