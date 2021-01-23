    public void translate(double tx, double ty, double tz)
    {
        if (!Application.Current.Dispatcher.CheckAccess())
        {
            Application.Current.Dispatcher.BeginInvoke(
                new Action(() => translate(tx, ty, tz)));
        }
        else
        {
            Transform3DGroup transform = new Transform3DGroup();
            TranslateTransform3D t = new TranslateTransform3D(tx, ty, tz);
            transform.Children.Add(t);
        }
    }
