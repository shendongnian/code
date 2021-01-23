    return (from detail in camOnlineDb.Details
            join suppDepp in camOnlineDb.SuppDepts
                on new { detail.ClientID, detail.CategoryID }
            equals new { suppDepp.ClientID, suppDepp.CategoryID }
            select new DepartmentBreakdownReport
            {
                Property1 = detail.Property1,
                //your properties here
            });
