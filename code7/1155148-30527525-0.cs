    public class VotesContext : DbContext {
            public DbSet<Vote> Votes { get; set; }
            public DbSet<VoteInfo> VoteInfos { get; set; }
        }
        
        public class Vote {
            public int VoteId { get; set; }
            public string VoteYear { get; set; }
            public virtual ICollection<VoteInfo> VoteInfo { get; set; }
        }
        
        public class VoteInfo {
            public int VoteInfoId { get; set; }
            public string VoterId { get; set; }
        }
