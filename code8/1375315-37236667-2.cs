        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            //Get the middle of the panel
            var x_0 = panel1.Width / 2;
            var y_0 = panel1.Height / 2;
            var shape = new PointF[6];
            var r = 70; //70 px radius 
            //Create 6 points
            for(int a=0; a < 6; a++)
            {
                shape[a] = new PointF(
                    x_0 + r * (float)Math.Cos(a * 60 * Math.PI / 180f), 
                    y_0 + r * (float)Math.Sin(a * 60 * Math.PI / 180f));
            }
            graphics.DrawPolygon(Pens.Red, shape);            
        }
