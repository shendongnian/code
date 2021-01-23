    public static Pipeline<TInput, BusinessEntity> ConditionalNext<TInput>(
        this Pipeline<TInput, BusinessEntity> pipeline,
        Func<BusinessEntity, BusinessEntity> func)
    {
        return pipeline.Next(x => x.Equals(BusinessEntity.Null) ? x : func(x));
    }
