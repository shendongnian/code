    class A<T>
    {
        public virtual List<T> GetBulkStuff() { throw new Exception(); }
    }
    class B : A<ModelBRecords>
    {
        public override List<ModelBRecords> GetBulkStuff()
        {
            return base.GetBulkStuff();
        }
    }
