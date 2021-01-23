    public class B<D> : A<D> where D : C
    {
        public D GetCSubclass()
        {
            return this.cSubclass;
        }
    }
