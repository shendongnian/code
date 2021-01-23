    public static IQueryable<BusinessUnitDTO> GetBusinessUnitDTO(this IQueryable<BusinessUnit> q)
    {
        return q.Select(b => new BusinessUnitDTO
        {
            Name = b.Name,
            CurrencyCode = b.Currency.Code,
        };
    }
