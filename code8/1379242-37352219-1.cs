    public abstract class A<T> where T : A<T>
    {
        protected List<A<T>> containerList;
        public Collection<T> ContainerList
        {
            get { return new Collection<T>(containerList.OfType<T>().ToList()); }
        }
    }
    public class B : A<B>
    {
       //...
    }
    public class C : A<C>
    {
       //...
    }
