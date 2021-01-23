      internal class EntityMappingProfile :Profile
    {
        protected override void Configure()
        {
            base.Configure();
            this.CreateMap<Link, LinkEntity>();
        }
    }
