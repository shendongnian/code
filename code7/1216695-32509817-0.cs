    [Serializable]
    public class A : IObjectReference
    {
        private string ID = null;
        private string Name = null;
        public A()
        { }
        public static A Empty = new A()
        {
            ID = "Empty",
            Name = "Empty"
        };
        #region IObjectReference Members
        object IObjectReference.GetRealObject(StreamingContext context)
        {
            if (this.GetType() == Empty.GetType() // Type check because A is not sealed
                && this.ID == Empty.ID
                && this.Name == Empty.Name)
                return Empty;
            return this;
        }
        #endregion
    }
