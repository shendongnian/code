    public class Example {
       public int ExampleId {get; set;}  
       public int OldestFriendId {get; set;}
       public int BestFriendId {get; set;}
       public virtual Friend Oldest {get; set; }
       public virtual Friend Best {get; set; }
     }
    entity.HasOptional(t => t.Best)
          .WithMany()
          .HasForeignKey(t => t.BestFriendId);
    entity.HasOptional(t => t.Oldest)
          .WithMany()
          .HasForeignKey(t => t.OldestFriendId);
