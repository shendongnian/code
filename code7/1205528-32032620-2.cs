            private void Form1_Load(object sender, EventArgs e)
            {
                 
            }
    
            private void panel2_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.DrawRectangle(
                    new Pen(Color.Green, 3),
                    new Rectangle(10, 10, 50, 50));
                //Drawing an ellipse
                e.Graphics.FillEllipse(Brushes.Green, new Rectangle(60, 60, 100, 100));
                //Drawing text
                e.Graphics.DrawString("Text", new Font("Verdana", 14), new SolidBrush(Color.Green), 200, 200);
            }
    
            private void button1_Click_1(object sender, EventArgs e)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
    
            private void button2_Click_1(object sender, EventArgs e)
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
            
            // code described below
            public class MyDisplay : Panel
            {
                public MyDisplay()
                {
                    this.DoubleBuffered = true;
                }
            }            
