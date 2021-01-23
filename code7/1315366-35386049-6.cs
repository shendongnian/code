    abstract class Cloneable<T> where T : Cloneable<T>
    {
        public abstract T Clone();
    }
    sealed class MyCloneable : Cloneable<MyCloneable>
    {
        public override MyCloneable Clone()
        {
            return new MyCloneable();
        }
    }
    MyCloneable instance = new MyCloneable();
    MyCloneable clone = instance.Clone();
