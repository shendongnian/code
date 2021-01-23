    private void OnMouseDown(object sender, MouseButtonEventArgs e)
    {     
        Viewport3DX vp = e.Source as Viewport3DX;
        Point3D p;
        Vector3D v;
        Model3D m;
        if (vp.FindNearest(e.GetPosition(vp), out p, out v, out m))
        {
             //Do something with the found object
        }
     }
