    public interface ISomeBindingList<out T>
    {
    }
    public abstract class ParentClass
    {
        public abstract ISomeBindingList<ParentClass> parentList();
    }
    public class ChildClass : ParentClass
    {
        private ISomeBindingList<ChildClass> myList;
        public ChildClass()
        {
            // this could load from/bind to a database
            // myList = new SomeBindingList<ChildClass>(); // <-- we need to figure out this
        }
        public override ISomeBindingList<ParentClass> parentList()
        {
            return myList;
        }
    }
