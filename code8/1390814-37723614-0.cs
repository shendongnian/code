    interface IViewModelLifeCycle
    {
       void Activate();
       void Deactivate();
    }
    public class MyComponentViewModel: BindableBase, IViewModelLifeCycle {
       public void Activate(){}
       public void Deactivate()
    }
