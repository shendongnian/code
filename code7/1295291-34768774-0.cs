     //mappings for csv download
            Mapper.CreateMap<TeamFeedMessage, MessageCsv>()
                  .ForMember(dest => dest.Alias, opt => opt.MapFrom(t => (t.Message.Contributor.Channel == ChannelEnum.GnipTwitter || t.Message.Contributor.Channel == ChannelEnum.Twitter)? t.Message.Contributor.UserName : t.Message.Contributor.Alias))
    public sealed class TeamFeedMessageMap : CsvClassMap<MessageCsv>
    {
        public TeamFeedMessageMap()
        {
            AutoMap();
        }
    }
                  
                  
