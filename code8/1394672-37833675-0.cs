    {... }
    .ForMember(dest => dest.Date,
                            opt => opt.MapFrom(src =>
                            {
                                try
                                {
                                    var day = Convert.ToInt32(src.Date.Substring(0, 2));
                                    var month = Convert.ToInt32(src.Date.Substring(3, 2));
                                    var year = Convert.ToInt32(src.Date.Substring(6, 4));
        
                                    return new WcfDate(new DateTime(year, month, day));
                                }
                                catch
                                {
                                    throw new ArgumentException("Premium date conversion error for date {0}.", src.Date);
                                }
                            }));
