    public class Child
    {
        public int Id { get; set; }
        public int ChildChildId { get; set; }
        public int FatherId { get; set; }
        #region Navigations Properties
        public virtual Father Father { get; set; }
        public virtual ChildChild ChildChild { get; set; }
        #endregion
    }
