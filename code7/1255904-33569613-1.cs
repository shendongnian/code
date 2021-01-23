    // Views are declared the same way
    public abstract class Model<TView>
        where TView: View
    {
        public abstract TView View { get; }
    }
    public class _3DModel : Model<_3DView>
    {
        public override _3DView View { get { return new _3DView; } }
    }
    public class _2DModel : Model<_2DView>
    {
        public override _2DView View { get { return new _2DView; } }
    }
    Model<_3DView> model = new _3DModel();
    model.View.Hello();
