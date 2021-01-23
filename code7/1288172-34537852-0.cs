    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            private Dictionary<int, Image> _dictionary;
            private Size _imageSize;
            private int[] _level;
            private Size _levelSize;
            private Point _mousePos;
    
            public Form1()
            {
                InitializeComponent();
                pictureBox1.Paint += PictureBox1_Paint;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                InitializeLevel();
                Redraw();
            }
    
            private void InitializeLevel()
            {
                var imageEmpty = Image.FromFile("empty.png");
                var imageMouse = Image.FromFile("mouse.png");
                var imageWall = Image.FromFile("wall.png");
                _level = new[]
                {
                    0, 0, 0, 0, 0,
                    0, 1, 1, 1, 0,
                    0, 1, 1, 1, 0,
                    0, 1, 1, 1, 0,
                    0, 0, 0, 0, 0
                };
                _levelSize = new Size(5, 5);
                _imageSize = new Size(25, 25);
                _dictionary = new Dictionary<int, Image>();
                _dictionary.Add(0, imageWall);
                _dictionary.Add(1, imageEmpty);
                _dictionary.Add(2, imageMouse);
                _mousePos = new Point();
            }
    
            private void Redraw()
            {
                pictureBox1.Invalidate();
            }
    
            private void PictureBox1_Paint(object sender, PaintEventArgs e)
            {
                var graphics = e.Graphics;
                graphics.Clear(Color.Transparent);
                // draw level
                var i = 0;
                foreach (var tile in _level)
                {
                    var x = i % _levelSize.Width;
                    var y = i / _levelSize.Width;
                    var image = _dictionary[tile];
                    graphics.DrawImage(image, new Point(x * _imageSize.Width, y * _imageSize.Height));
                    i++;
                }
                // draw hero !
                graphics.DrawImage(_dictionary[2], _mousePos);
            }
    
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                var up = keyData == Keys.Up;
                var down = keyData == Keys.Down;
                var left = keyData == Keys.Left;
                var right = keyData == Keys.Right;
    
                var processed = up || down || left || right;
                if (!processed) return base.ProcessCmdKey(ref msg, keyData);
    
                // move the hero !
                var x = 0;
                var y = 0;
                if (left) x--;
                if (right) x++;
                if (up) y--;
                if (down) y++;
                _mousePos.X += x;
                _mousePos.Y += y;
                Redraw();
                return true;
            }
        }
    }
