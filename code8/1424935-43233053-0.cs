    var geo = new MeshGeometry3D { Positions = new Point3DCollection(pointsLists), TriangleIndices = new Int32Collection(indexes) };
    geo.Freeze();
    
    var mat = new DiffuseMaterial(Brushes.Gray); mat.Freeze();
    var bMat = new DiffuseMaterial(Brushes.Red); bMat.Freeze();
    
    var geomod = new GeometryModel3D(geo, mat);
    geomod.BackMaterial = bMat;
    
    geomod.Transform = new ScaleTransform3D();
    var bndng = new Binding("ScaleValue");
    bndng.Source = SomeViewModel;//Here put the propriate viewmodel
    BindingOperations.SetBinding(geomod.Transform, ScaleTransform3D.ScaleXProperty, bndng);
    BindingOperations.SetBinding(geomod.Transform, ScaleTransform3D.ScaleYProperty, bndng);
    BindingOperations.SetBinding(geomod.Transform, ScaleTransform3D.ScaleZProperty, bndng);
    
    geomod.Geometry = geo;
    Model3DGroup.Children.Add(geomod);//Here you have to find reference to you Model3DGroup
