    public List<ProductRequestDetailDto> GetProductRequestExtendedDetailAll()
    {      
        List<ProductRequest> aProductRequestList = unitOfWork.getProductRequestRepository().GetProductRequestExtendedDetailAll();
    
        Mapper.CreateMap<ProductRequest, ProductRequestDetailDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Employee.FirstName))
            .ForMember(dest => dest.MiddleInitial, opt => opt.MapFrom(src => src.Employee.MiddleInitial))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Employee.LastName))
            .ForMember(dest => dest.DeptName, opt => opt.MapFrom(src => src.Employee.Department.DeptName))
            .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => src.ProductProfile.DeviceType))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductProfile.ProductName))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductProfile.ProductId))
            .ForMember(dest => dest.ProductRequestStageId, opt => opt.MapFrom(src => src.ProductRequestStage.ProductRequestStageId));
    
        List<ProductRequestDetailDto> ProductRequestDetailDtoList = aProductRequestList.ProjectTo<ProductRequestDetailDto>().ToList();
    
        // or also
        // List<ProductRequestDetailDto> ProductRequestDetailDtoList = aProductRequestList.Select(Mapper.Map<ProductRequestDetailDto>).ToList();
    
        return ProductRequestDetailDtoList;
    }
    
    public List<ProductRequest> GetProductRequestExtendedDetailAll()
    {
        var ReportResult = from Req in context.ProductRequests
                           select Req;
    
        return ReportResult;
    }
