    private delegate void MyFunctionDelegate2(double t1, double t2, double t3);
    public void translate(double tx, double ty, double tz)
    {
        if (!Application.Current.Dispatcher.CheckAccess())
        {
            var t = new MyFunctionDelegate2(translate);
            Application.Current.Dispatcher.BeginInvoke(t, tx, ty, tz);
        }
        else
        {
            var transform = new Transform3DGroup();
            var t = new TranslateTransform3D(tx, ty, tz);
            transform.Children.Add(t);
        }
    }
