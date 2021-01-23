    public class ShareDetailsMap : ClassMap<ShareDetails>
        public ShareDetailsMap(){
            LazyLoad();
            //Don't think you need these since this isn't a db table
            //Id(x => x.DocumentId).GeneratedBy.Identity().Column("id");
            //Map(x => x.CreationDate).Column("creation_date");
            References(x => x.Annual).Column("creation_date");
            References(x => x.Monthly).Column("creation_date");
            References(x => x.ShareValue).Column("creation_date");
            References(x => x.MiscDetails).Column("creation_date");
        }
    }
