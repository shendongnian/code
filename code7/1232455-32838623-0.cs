    namespace Tests
    {
    [TestFixture]
    public class Mapping
    {
        [SetUp]
        public void initialize()
        {
            Core.Mappings.AutoMapperConfiguration.Configure();
        }
        [Test]
        public void configutation()
        {
            AutoMapper.Mapper.AssertConfigurationIsValid<Core.Mappings.Profiles.FollowUpActivityProfile>();
        }
        [Test]
        public void followUpActivityDTOToDOMAIN()
        {
            LEST.Model.FollowUpActivityDTO dto = new LEST.Model.FollowUpActivityDTO()
            {
                Id = new Guid().ToString(),
                Timestamp = DateTime.UtcNow,
                StartTimestamp = DateTime.UtcNow,
                DueTimestamp = DateTime.UtcNow,
                ClosingTimestamp = DateTime.UtcNow,
                Matter = "Matter",
                Comment = "Comment",
                Status = "open",
                BacklogStatus = "work",
                Metainfos = new System.Collections.Generic.List<LEST.Model.MetaInfoValueDTO>()
            };
            Domain.FollowUpActivity domain = new Domain.FollowUpActivity();
            AutoMapper.Mapper.Map<LEST.Model.FollowUpActivityDTO, Domain.FollowUpActivity>(dto, domain);
            domain.Should().NotBeNull();
            domain.Id.Should().Be(dto.Id);
        }
    }
    }
