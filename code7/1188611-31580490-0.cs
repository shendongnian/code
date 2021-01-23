    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Subselect("SELECT DISTINCT UserId FROM OldTable");
            ReadOnly();
            Id(x => x.UserId);
            HasMany(x => x.UserSelection).Table("OldTable").KeyColumn("UserId");
        }
    }
    public class UserSelectionMap : ClassMap<UserSelection>
    {
        public UserSelectionMap()
        {
            Table("OldTable");
            Id(x => x.SelectionId);
            Map(x => x.DateSelected);
            References(x => x.User).Column("UserId").Not.Nullable();
        }
    }
