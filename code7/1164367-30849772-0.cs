    class MyDto
    {
        public int? StatusId;
        public int? OtherStatusId;
    }
    class MyModel
    {
        public int StatusId; 
    }
    // this should work normally
    .ForMember(d => d.StatusId, c => c.MapFrom(f => f.Order.StatusId));
    // this causes the exception above, but I don't know why, 
    // maybe because I have some quite complex mapping
    .ForMember(d => d.OtherStatusId, c => c.MapFrom(f => f.Other.StatusId));
    // apply a cast on the source expression make the mapping smoothly
    .ForMember(d => d.OtherStatusId, c => c.MapFrom(f => (int?)f.Other.StatusId));
