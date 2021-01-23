    public Result<IList<Organisation>> GetAllOrganisations(bool showCompanyPagesOnly = false)
    {
        var result = new Result<IList<Organisation>>();
        try
        {
            var organizations = Context.Set<Domain.Content.Organisation>()
                .AsNoTracking();
            if (showCompanyPagesOnly)
                organizations=organization
                .Where(x => x.ShowCompanyPage == true);
            result.Data = organizations
                .Select(x => new DataContracts.Content.Organisation
                {
                    Id = x.Id,
                    Name = x.Name,
                    OrganisationTypeId = x.OrganisationTypeId,
                    IsCustomer = x.IsCustomer,
                    SeoName = x.SeoName,
                    Description = x.Description,
                    Website = x.Website
                }).OrderBy(x => x.Name).ToList();
        }
        catch (Exception ex)
        {
            result.SetException(ex);
            HandleError(ex);
        }
        return result;
    }
