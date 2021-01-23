    public interface IBinder<TModel,TView>
    {
         void Bind(TModel model, TView view);
    }
    public class MyBinder: IBinder<MyModel1,MyView1>
    {
        public void Bind(MyModel1 model, MyView1 view)
        {
             view.SomeProperty = model.SomeOtherProperty;
             //.. And so on.
        }
    }
