    public class Location
    {
        public virtual Guid Id { get; set; }
        public virtual Parent Owner { get; set; }
        public virtual string SomeProperty { get; set; }
        //This is the mapping for this class.
        public class LocationMapping : ClassMap<Location>
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.SomeProperty);
            //This will relate our property back to the parent.
            References(x => x.Owner);
        }
    }
