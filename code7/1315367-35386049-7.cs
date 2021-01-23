    abstract class Cloneable
    {
        public abstract Cloneable Clone();
    }
    sealed class MyCloneable : Cloneable
    {
        public override Cloneable Clone()
        {
            return new MyCloneable();
        }
    }
    MyCloneable instance = new MyCloneable();
    MyCloneable clone = (MyCloneable)instance.Clone(); // Note the cast.
