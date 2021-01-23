    public class Artist
    {
      public int ArtistId { get; set; }
      
      public int? RelatedToId{ get; set; }
      public virtual Artist RelatedTo {get;set;}
     public virtual ICollection<Artist> RelatedArtists {get;set;}
    }
