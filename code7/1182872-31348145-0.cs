    public void Mymethod()
    {
       // Callind the event
       SpatialControl_MouseDoubleClick(new object(), new MouseButtonEventArgs()) 
       // Executing other code.
       DrawingControl.Viewport.Camera.Position = new Point3D(100, 100, 1);
       DrawingControl.Viewport.SetView(new Point3D(-1,-1,-1), new Vector3D(1,1,1), new Vector3D(1,2,1),5);
    }
