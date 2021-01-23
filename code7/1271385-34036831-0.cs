    var list = (from p in ProjectManagement.Context.Project
                   join a in ProjectManagement.Context.Account
                   on p.AccountId equals a.AccountId
                   select new ProjectView(){
                       AccountId = a.AccountId,
                       ProjectId = p.ProjectId,
                       ProjectName = p.ProjectName,
                       InvoicedHours = p.InvoicedHours,
                       AccountName = a.CompanyName,
                       AllottedHours = p.AllottedHours,
                       RemainingHours = p.RemainingHours,
                       UninvoicedHours = p.UninvoicedHours
                   }).ToList();
