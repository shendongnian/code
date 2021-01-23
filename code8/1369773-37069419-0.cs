    protected override void OnMouseClick(MouseEventArgs e)
    {           
        Point position = e.GetPosition(this); 
        int x = (int)e.X;
        int y = (int)e.Y;       
        faces.Add(new Face (x, y, 5, 5, 20));
        InvalidateVisual();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        foreach(Face face in faces)
        {
            face.DrawFace(g);    
            face.DrawLeftEye(g);
            face.DrawRightEye(g);
        }
    }    
