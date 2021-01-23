    public class BoxDefinition : ISiblingable
    {
         //other stuff....
         [ForeignKey("Next")]
         [Index(IsUnique = true)]        
         public int? NextId { get; set; }
         [ForeignKey("Previous")]
         [Index(IsUnique = true)]        
         public int? PreviousId { get; set; }
 
         public BoxDefinition Next { get; set; }
         public BoxDefinition Previous { get; set; }
         [Obsolete]
         [InverseProperty("Next")]
         public virtual ICollection<BoxDefinition> NextSiblings { get; set; }
         [Obsolete]
         [InverseProperty("Previous")]
         public virtual ICollection<BoxDefinition> PreviousSiblings { get; set; }
    }
