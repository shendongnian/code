        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawCutCircle(e.Graphics, new Point(210, 210), 200, 80);
        }
