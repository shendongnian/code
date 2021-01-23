    public IEnumerable<dynamic> GetAdditionalAttributes(object aModel)
    {
        return aModel.GetType().GetProperties()
        .Where(p => p.IsDefined(typeof(AdditionalModelAttributes), false))
        ...
