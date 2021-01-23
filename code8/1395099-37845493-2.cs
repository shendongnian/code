    public abstract class A<T> : A where T : A
    {
        protected override void SetG()
        {
            this.g = new G<T>();
        }
    }
