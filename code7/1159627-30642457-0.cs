    public class AddressSearchList_ToResponse_Profile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Address, AddressSearchResponseDto>()
                .ConvertUsing<ConvertAddressToSearchList>();
    
        }
    }
