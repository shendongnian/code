    Transform3DGroup  myTransformer = new Transform3DGroup;  
    RotateTransform3D myRotate = new RotateTransform3D(new AxisAngleRotation3D    (new Vector3D(0, 0, 1), Convert.ToDouble(180)), new Point3D(0, 0, 0));
    TranslateTransform3D myTranslate = new TranslateTransform3D(0, 0, 100);
    myTransformer.Children.Add(myRotate);
    myTransformer.Children.Add(myTranslate);
    ModelVisual3D device3D2 = new ModelVisual3D();
    device3D2.Content = Display3d(MODEL_PATH2);
    device3D2.Transform = myTransformer;
    viewPort3d.Children.Add(device3D2);
