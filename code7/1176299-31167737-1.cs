    protected override int GetAllErrors(List<Error> errors, string applicationName = null)
    {
        using (var c = GetConnection())
        {
            errors.AddRange(c.Query<Error>(@"
    Select Top (@max) * 
    From Exceptions 
    Where DeletionDate Is Null
    And ApplicationName = @ApplicationName
    Order By CreationDate Desc", new { max = _displayCount, ApplicationName = applicationName.IsNullOrEmptyReturn(ApplicationName) }));
        }
        return errors.Count;
    }
