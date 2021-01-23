    [Serializable]
    [DataContract(IsReference = true)]
    [KnownType(typeof(Visit))]
    public partial class Visit
    {
      public int Id { get; set; }
      public int VisitType { get; set; }
      public System.DateTime VisitDate { get; set; }
      public Nullable<int> Visitor_Id { get; set; }
      public virtual Visitor Visitor { get; set; }
    }
