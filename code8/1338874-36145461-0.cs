    public class UserMap : ClassMap<UserModel>
    {
        public UserMap()
        {
            this.Table("Users");
            this.Id(x => x.Id)
                .GeneratedBy.Native();
            this.Map(x => x.Name)
                .Length(int.MaxValue)
                .Not.Nullable();
        }
    }
