       public static int slider;  
        
        public void trackBar1_Scroll(object sender, EventArgs e)
            {
              slider  = (int)trackBar1.Value ;
            }
            public void DrawCar ()
            {
                drawArea = drawingArea.CreateGraphics();
                Pen blackpen = new Pen(Color.Orange);
                drawArea.DrawLine(blackpen, slider , 10, 500, 500);
                drawArea.DrawArc(Pens.Orange, new Rectangle( 10 , 10, 100, 100), 50, 100);
            }
