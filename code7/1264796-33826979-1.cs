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
