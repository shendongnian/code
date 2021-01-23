    using AutoMapper;
    using TreasuryRecords.Database.Models;
    using TreasuryRecords.Requests.Account.Models;
    public class AccountMappings : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<RegisterDto, Client>()
                .ForMember(x => x.UserName, c => c.MapFrom(x => x.Email));
        }
    }
