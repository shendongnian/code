    private void spatialControl_DoubleClick()
    {
        _camChanged = false;
        DrawingControl.Viewport.Camera.Changed += Camera_Changed;
        DrawingControl.ZoomSelected();
        DrawingControl.Viewport.Camera.Changed -= Camera_Changed;
        if (!_camChanged)
            DrawingControl.ClipBaseSelected(0.15);
        DrawingControl.Viewport.Camera.Position = new Point3D(100, 100, 1);
        DrawingControl.Viewport.SetView(new Point3D(-1,-1,-1), new Vector3D(1,1,1), new Vector3D(1,2,1),5);
    }
    private void SpatialControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        spatialControl_DoubleClick();
    }
