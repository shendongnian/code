    adviceVM.Companies = ledgerService.GetAll().OrderBy(t => t.Name)
                                               .Select(t=>
                                                   new CompanyVM
                                                   {
                                                       Id = t.Id,  // "Id"
                                                       Name = t.Name // "Name"
                                                   })
                                                .ToList();
