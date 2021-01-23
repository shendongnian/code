    public static async Task<List<DropDownSelect>> SelectReportDropDown(bool isPpm, int companyId = 0)
    {
        using (var context = ContextFactory.getLiveConnection())
        {
            var result = await context.Companies.Select(c => new // this is an anonymous type
            {
                Id = c.ID,
                Name = c.Name,
                Next = c.Reports.Select(p => new DropDownSelect //DropDownSelect is now used in only one place in the query
                {
                    Id = p.ProjectId,
                    Name = p.Name,
                }).ToList()
            }).ToListAsync();
            return result.Select(x => new DropDownSelect
            {
                Id = x.Id,
                Name = x.Name,
                Next = x.Next
            }).ToList();
        }
    }
