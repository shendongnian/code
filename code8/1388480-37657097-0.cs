            private int _firstX;
            private int _firstY;
            private int _secondX;
            private int _secondY;
    
            private bool _isSecondClick;
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_isSecondClick)
            {
                _secondX = Cursor.Position.X;
                _secondY = Cursor.Position.Y;
                var radious1 = Math.Pow(_firstX - _secondX, 2);
                var radious2 = Math.Pow(_firstY - _secondY, 2);
                var radious = Math.Sqrt(radious1 + radious2);
                Graphics g = this.CreateGraphics();
                Rectangle rectangle = new Rectangle();
                PaintEventArgs arg = new PaintEventArgs(g, rectangle);
                DrawCircle(arg, _secondX, _secondY, radious, radious);
            }
            else
            {
                _firstX = Cursor.Position.X;
                _firstY = Cursor.Position.Y;
                _isSecondClick = true;
            }    
        }
        private void DrawCircle(PaintEventArgs arg, int x, int y, double width, double height)
        {
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Red, 3);
            var xL = Convert.ToInt32(x - width / 2);
            var yL = Convert.ToInt32(y - height / 2);
            var hL = Convert.ToInt32(height);
            var wL = Convert.ToInt32(width);
            arg.Graphics.DrawEllipse(pen, xL, yL, wL, hL);
        }
