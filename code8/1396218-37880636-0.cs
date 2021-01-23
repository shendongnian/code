    public class BoxDefinition : ISiblingable
    {
         //other stuff....
         [Obsolete]
         [InverseProperty("Next")]
         public virtual ICollection<BoxDefinition> NextSiblings { get; set; }
         [Obsolete]
         [InverseProperty("Previous")]
         public virtual ICollection<BoxDefinition> PreviousSiblings { get; set; }
    }
