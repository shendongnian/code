    public abstract class View 
    {
        public abstract void Hello();
    }
    public class _3DView : View
    {
        public override void Hello() 
        {
            Console.WriteLine("Hello from 3D View");
        }
    }
    public class _2DView : View
    {
        public override void Hello() 
        {
            Console.WriteLine("Hello from 2D View");
        }
    }
    public abstract class Model
    {
        public abstract View { get; }
    }
    public _3DModel : Model 
    {
        public override View  { get { return new _3DView; } }
    }
    public _2DModel : Model 
    {
        public override View  { get { return new _2DView; } }
    }
    Model model = new _3DModel();
    model.View.Hello(); // have "Hello from 3D View"
    Model anotherModel = new _2DModel();
    anotherModel.View.Hello();  // have "Hello from 2D View"
