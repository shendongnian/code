    [Serializable]
    [DataContract(IsReference = true)]
    [KnownType(typeof(Visit))]
    public partial class Visit
    {
      [DataMember]
      public int Id { get; set; }
      [DataMember]
      public int VisitType { get; set; }
      [DataMember]
      public System.DateTime VisitDate { get; set; }
      [DataMember]
      public Nullable<int> Visitor_Id { get; set; }
      [DataMember]
      public virtual Visitor Visitor { get; set; }
    }
