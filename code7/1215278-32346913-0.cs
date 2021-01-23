    public override TDtoType MapToDto<TDtoType>(IEntity entity)
    {
        var dto = typeof(TDtoType) == typeof(SensitiveDto) 
            ? new SensitiveDto() 
            : new BaseDto();
    
        this.Engine.Map(entity, dto);
        return dto as TDtoType;
    }
