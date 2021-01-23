    public abstract class MyObject
    {
        protected Presenter Presenter;
        protected abstract MyObject Find();
        protected void FindAndSetAcive()
        { 
           MyObject newActiveObject = Find();
           Presenter.ActiveObject = newActiveObject;
        }
    }
     public class Child : MyObject
     {
      public override MyObject Find()
      {
        Results results = ChildSearch.Find(this);
        Child newChild = new Child(results);
        return newChild;
      }
    }
     public class Parent: MyObject
     {
      public override MyObject Find()
      {
         child.find();
         // here you can do what you have to do to get the new "active element"
        return this;
      }
    }
