    public void RenderAnts(object sender, PaintEventArgs e)
    {
        using (Graphics G = Graphics.FromImage(pictureBox1.Image))
        {
            Map.EvaporatesPheromones();
            foreach (Vector2D food in foodSrcs)
            {
               Map.SetMapPoint(food, 500);
            }
            foreach (Ant a in ants)
            {
               Brush c = Brushes.DarkBlue;
               if (a.role == AntRole.Scout)
               {
                  a.Move(j);
                  c = Brushes.Red;
               }
               e.Graphics.FillRectangle(c, a.position.x, a.position.y, 1, 1);
               G.FillRectangle(Brushes.Gray, a.position.x, a.position.y, 1, 1);
            }
        }
    }
