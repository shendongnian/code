    List<Point> arr_points = new List<Point>();
     int i = 0;
     private void Form1_Load(object sender, EventArgs e)
            {
                arr_points.Add(new Point(500, 400));
                arr_points.Add(new Point(25, 516));
                arr_points.Add(new Point(0, 0));
            }
    
           
    
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (i == arr_points.Count)
                {
                    i = 0;
                }
                if (e.KeyCode == Keys.A)
                    this.Location = arr_points[i];
                i++;
    
            }
