    public interface IAmB<T> where T : IAmA
    {
        void foo(T p);
    }
    public class ClassB : IAmB<ClassA>
    {
        void foo(ClassA p)
        {
            p.someIntField++;
        }
    }
