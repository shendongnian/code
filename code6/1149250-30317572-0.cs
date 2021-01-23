    public GateShape(Gate gate, int x, int y, float zoomFactor, PaintEventArgs p)
    {
      _gate = gate;
      P = p;
      StartPoint = new Point(x, y);
      ShapeSize = new Size(20, 20);
      ZoomFactor = zoomFactor;
      Draw();
    }
    public Bitmap Draw()
    {
      P.Graphics.ScaleTransform(ZoomFactor, ZoomFactor);
      ...
      // The rest of rendering logic should be the same (as is previously written)
    }
