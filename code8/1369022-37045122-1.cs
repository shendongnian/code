     private static Mapper _mapper;
        public static Mapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Claim, ClaimItem>(MemberList.Destination);
                    });
                    config.AssertConfigurationIsValid();
                    _mapper = config.CreateMapper();
                }
                return _mapper;
            }
        }
