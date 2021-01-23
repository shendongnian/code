    private void ContextMenuOpen(object sender, ContextMenuEventArgs e)
        {
            Point location = Mouse.GetPosition(myViewport);
            HitTestResult hit = VisualTreeHelper.HitTest(myViewport, location);
            var meshit = hit as RayMeshGeometry3DHitTestResult;
            SurfaceInfo inf = model3D.FindInfo(meshit.ModelHit);
            if (inf == null) // if Model3D object weren't touched 
            {
                e.Handled = true;
            }
        }
