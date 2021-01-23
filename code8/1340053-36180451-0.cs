    Graphics g = new Graphics()
    Rectangle car = new Rectangle(200, 200, 100, 50)
    Matrix m = new Matrix()
    m.RotateAt(orientation, new PointF(car.Left + (car.Width / 2), car.Top + (car.Height / 2)));
    g.Transform = m
    g.FillRectangle(Pens.Red, car)
