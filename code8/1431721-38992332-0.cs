    var propertyModel = db.LoanProperties
            .Where(p => p.LoanApplicationId == newApplication.LoanId)
            .Select(p => new PropertyViewModel(
                    AddressLine1 = p.AddressLine1,
                    AddressLine2 = p.AddressLine2,
                    TotalRentPerAnnum = p.TotalRentPerAnnum,
                    Tenants = p.Tenants.Select(t=> new TenantViewModel(.....)))
            .FirstOrDefault();
