    public class Parent
    {
        public virtual Guid Id { get; set; }
        public virtual IList<Location> Locations { get; set; }
        //This is the mapping for this class.
        public class ParentMapping : ClassMap<Parent>
        {
            Id(x => x.Id).GeneratedBy.Guid();
            //This is what relates your location list to this parent.
            //Notice that in the Location object below, 
            //there's a Owner property which will point back to here.
            HasMany(x => x.Locations).Cascade.All();
        }
    }
