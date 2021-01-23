    public abstract class Model<TView> : Model where TView : View
    {
        public new TView _view
        {
            get { return base._view as TView; }
            set { base._view = value; }
        }
    }
    public class View3D : View { }
    public class Model3D : Model<View3D> { }
    public class View2D : View { }
    public class Model2D : Model<View2D> { }
