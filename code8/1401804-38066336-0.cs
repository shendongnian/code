    private IEnumerable<InvoiceSummery> CreateSummery(IEnumerable<Invoice> invoices)
    {
        // Removed 'UserId`  
        return invoices.GroupBy(x => new { x.User.Nationality.Name, x.User.UserType.TypeName, x.User.Code, x.City,x.PaymentPlan })
            .Select(g => new InvoiceSummery
            {
                Nationality = g.Key.Name,
                TypeName = g.Key.TypeName,
                Code = g.Key.Code,
                PaymentPlan = g.Key.PaymentPlan ,
                City = g.Key.City,
                UserCount = g.Count(),
                GrandTotal = g.Sum(s => s.Total)
            });
    }
