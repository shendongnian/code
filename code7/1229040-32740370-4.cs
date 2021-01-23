    public class ShareDetailsMap : ClassMap<ShareDetails>
        public ShareDetailsMap(){
            LazyLoad();
            Id(x => x.DocumentId).GeneratedBy.Identity().Column("id");
            Map(x => x.CreationDate).Column("creation_date");
            References(x => x.Annual).Column("creation_date");
            References(x => x.Monthly).Column("creation_date");
            References(x => x.ShareValue).Column("creation_date");
            References(x => x.MiscDetails).Column("creation_date");
        }
    }
