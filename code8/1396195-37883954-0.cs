     public IList<MemberData> GetAllMember()
        {
            IList<MemberData> MemberDataList = null;
            IList<Member> memberList = _MembershipCoreServices.GetAllMember();
             if (memberList != null)
             {
                 var config = new MapperConfiguration(cfg =>
                 {
                     cfg.CreateMap<Member, MemberData>()
                              .ForAllMembers(opt => opt.Condition(srs => !srs.IsSourceValueNull));
                 });
                 IMapper mapper = config.CreateMapper();
                 MemberDataList = mapper.Map<IList<MemberData>>(memberList).ToList();
             }
           return MemberDataList;
           
        }
