    sealed class Derived : Base
    {
        protected override void Save(…)
        {
            Helper<Derived>.Save(this);
        }
    }
