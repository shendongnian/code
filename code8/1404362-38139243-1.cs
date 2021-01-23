    container = new QueryContainer();
    container = new QueryContainerDescriptor<BaseModel>().DateRange(qs => qs.Field(f => f.PublishedDate).LessThanOrEquals(TimeZoneInfo.ConvertTimeToUtc(DateTime.Now)));
    
    if (!string.IsNullOrEmpty(contentType) && !contentType.ToLower().Equals("all"))
    {
    	container &= new QueryDescriptor<BaseModel>().QueryString(qs => qs.OnFields(f => f.ContentType).Query(contentType));
    }
