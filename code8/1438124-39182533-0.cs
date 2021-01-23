    using (Graphics g = surface.CreateGraphics())
    {
        GraphicsPath gp1 = new GraphicsPath();
        GraphicsPath gp2 = new GraphicsPath();
        GraphicsPath gp3 = new GraphicsPath();
        GraphicsPath gp4 = new GraphicsPath();
        gp1.AddRectangle(fsnakes.SnakeRec[i]);
        gp2.AddPolygon(food.foodTrianglePoints);
        gp3.AddEllipse(food.food.foodCircle);
        gp4.AddRectangle(food.food.foodRec);
        Region reg1 = new Region(gp1);
        Region reg2 = new Region(gp2);
        Region reg3 = new Region(gp3);
        reg2.Intersect(reg1);
        reg3.Intersect(reg1);
        reg4.Intersect(reg1);
        if (!reg2.IsEmpty(g)) Win();
        if (!reg3.IsEmpty(g) || !reg4.IsEmpty(g)) restart();
    }
