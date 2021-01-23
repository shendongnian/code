    public partial class BBB
    {
      [ForeignKey("AAA")]
      public int AAAKey { get; set; }
      public virtual AAA AAA { get; set; }
      // other stuff...
    }
