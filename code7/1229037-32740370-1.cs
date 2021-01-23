    public class ShareDetailsMap : ClassMap<ShareDetails>
        public ShareDetailsMap(){
            LazyLoad();
            Id(x => x.DocumentId).GeneratedBy.Identity().Column("id");
            Map(x => x.CreationDate).Column("creation_date");
            References(x => x.Annual).Column("annual_creation_date");
            References(x => x.Monthly).Column("monthly_creation_date");
            References(x => x.ShareValue).Column("share_value_creation_date");
            References(x => x.MiscDetails).Column("misc_details_creation_date");
        }
    }
