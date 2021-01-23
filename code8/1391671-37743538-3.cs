    RightTriangle rt1 = new RightTriangle();
    Cone cn1 = new Cone();
    List<Point> objs = new List<Point>();
    objs.Add(rt1);
    Point object = objs[0];
    if (objs[0].IsAssignableFrom(RightTriangle))
        sideA_tb.Text = ((RightTriangle)objs[0]).sideA.ToString();
