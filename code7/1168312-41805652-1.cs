       var config = new MapperConfiguration(cfg =>
                        {
            Mapper.CreateMap<Report, ReportViewModel>()
                .ForMember(src => src.Value, 
                           dest => dest.ResolveUsing(r => {
                                switch(reportingPeriod)
                                {
                                    case ReportingPeriod.Daily:
                                        return r.Day.Value;
                                        break;
                                    case ReportingPeriod.Weekly:
                                        return r.Week.Value;
                                        break;
                                    case ReportingPeriod.Monthly:
                                        return r.Month.Value;
                                        break;
                                    case default:
                                        //None
                                        return null;
                                        break;
                                   }
                                }));
                });
        
           var mapper = config.CreateMapper();
