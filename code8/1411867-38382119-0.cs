    class Sample
    {
      public int Id{ get;set; }
      public int AssociatedSiteAId { get; set; } // Optional but sometimes useful if you don't use [ForegnKey("...")]
      [ForeignKey("AssociatedSiteAId")]
      public virtual SiteA Site { get; set; }
      public int AssociatedSiteBId { get; set; }  // Optional but sometimes useful if you don't use [ForegnKey("...")]
      [ForeignKey("AssociatedSiteBId")]
      public virtual SiteB SiteB { get; set; }
    }
